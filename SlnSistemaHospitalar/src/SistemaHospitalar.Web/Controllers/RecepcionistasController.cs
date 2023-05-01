using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaHospitalar.Domain.DTO;
using SistemaHospitalar.Domain.IServices;
using SistemaHospitalar.Web.Models;

namespace SistemaHospitalar.Web.Controllers
{
    public class RecepcionistasController : Controller
    {
        private readonly IRecepcionistaService _service;
        private readonly IPessoaService _pessoaService;

        public RecepcionistasController(IRecepcionistaService service, IPessoaService pessoaService)
        {
            _service = service;
            _pessoaService = pessoaService;
        }


        // GET: RecepcionistasController
        public async Task<IActionResult> Index()
        {
            var recepcionista = await _service.GetAll();
            return View(recepcionista);
        }

        // GET: RecepcionistasController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recepcionista = await _service.FindById(id);
            return View(recepcionista);
        }

        // GET: RecepcionistasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecepcionistasController/Create
        [HttpPost]

        public async Task<IActionResult> Create(RecepcionistaDTO recepcionista)
        {
            var pessoas = await _pessoaService.GetAll();

            int count = 0;
            foreach (var item in pessoas)
            {
                count++;
                if(count == pessoas.Count)
                {
                    var ultimaPessoa = item;
                    recepcionista.pessoaId = ultimaPessoa.id;
                }
            }

            if (ModelState.IsValid)
            {

                await _service.Save(recepcionista);
                TempData["MensagemSucesso"] = "Recepcionista adicionada(o) com sucesso";
                return RedirectToAction(nameof(Index));
            }
            TempData["MensagemErro"] = "Falha ao alterar Recepcionista ";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recepcionista = await _service.FindById(id);
            return View(recepcionista);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, RecepcionistaDTO recepcionista)
        {
            if (id == null || recepcionista == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _service.Save(recepcionista);
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
