using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaHospitalar.Domain.DTO;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.IServices;
using SistemaHospitalar.Web.Models;

namespace SistemaHospitalar.Web.Controllers
{
    public class EnderecosController : Controller
    {
        private readonly IEnderecoService _service;
        private readonly IPacienteService _pacienteService;
        private readonly IPessoaService _pessoaService;

        public EnderecosController(IEnderecoService service, IPacienteService pacienteService, IPessoaService pessoaService)
        {
            _service = service;
            _pessoaService = pessoaService;
            _pacienteService = pacienteService;

        }


        // GET: EnderecosController
        public async Task<ActionResult> Index()
        {
            var Endereco = await _service.GetAll();
            return View(Endereco);
        }

        public async Task<PartialViewResult> ListaEndereco(int id)
        {
            var lista = await _service.ListaEndereco(id);
            //var lista = await _service.GetAll();
            return PartialView(lista);
        }

        // GET: EnderecosController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var endereco = await _service.FindById(id);
            return View(endereco);
        }

        // GET: EnderecosController/Create
        public PartialViewResult Create()
        {
            return PartialView();
        }

        // POST: EnderecosController/Create
        [HttpPost]

        public async Task<JsonResult> Create(EnderecoDTO endereco)
        {
            

            var retDel = new ReturnJson
            {
                status = "Error",
                code = "400"
            };

            //if(id = 0){


            var pessoas = await _pessoaService.GetAll();

            int count = 0;
            foreach (var item in pessoas)
            {
                count++;
                if (count == pessoas.Count)
                {
                    //ultima Pessoa
                    endereco.pessoaId = item.id;
                }
            }

            if (ModelState.IsValid)
            {

                await _service.Save(endereco);
                TempData["MensagemSucesso"] = "Endereço adicionado com sucesso";
                retDel = new ReturnJson
                {
                    status = "Success",
                    code = "200"
                };
            };
            return Json(retDel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endereco = await _service.FindById(id);

            return View(endereco);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EnderecoDTO endereco)
        {
            if (id == null || endereco == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _service.Save(endereco);
                TempData["MensagemSucesso"] = "Registro alterado com sucesso";
                return RedirectToAction(nameof(Index));
            }

            TempData["MensagemErro"] = "Erro ao alterar registro";
            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        public async Task<JsonResult> Delete(int? id)
        {
            var retDel = new ReturnJson
            {
                status = "Success",
                code = "200"
            };
            try
            {
                if (await _service.Delete(id ?? 0) <= 0)
                {
                    retDel = new ReturnJson
                    {
                        status = "Error",
                        code = "400"
                    };
                }
            }
            catch (Exception ex)
            {
                retDel = new ReturnJson
                {
                    status = ex.Message,
                    code = "500"
                };
            }
            return Json(retDel);
        }
    }
}
