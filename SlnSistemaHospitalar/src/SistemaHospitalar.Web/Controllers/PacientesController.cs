using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaHospitalar.Domain.DTO;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.IServices;
using SistemaHospitalar.Web.Helper;
using SistemaHospitalar.Web.Models;

namespace SistemaHospitalar.Web.Controllers
{
    public class PacientesController : Controller
    {
        private readonly IPacienteService _service;
        private readonly IConvenioService _convenioService;
        private readonly IPessoaService _pessoaService;

        public PacientesController(IPacienteService service, IConvenioService convenioService, IPessoaService pessoaService)
        {
            _service = service;
            _convenioService = convenioService;
            _pessoaService = pessoaService;
        }


        // GET: PacientesController
        public async Task<ActionResult> Index()
        {
            var Paciente = await _service.GetAll();
            return View(Paciente);
        }

        // GET: PacientesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _service.FindById(id);
            return View(paciente);
        }

        // GET: PacientesController/Create
        public async Task<ActionResult> Create()
        {
            ViewData["convenioId"] = new SelectList(await _convenioService.GetAll(), "id", "nome", "Selecione...");
            return View();
        }

        // POST: PacientesController/Create
        [HttpPost]

        public async Task<IActionResult> Create(PacienteDTO paciente)
        {
            var pessoas = await _pessoaService.GetAll();

            int count = 0;
            foreach (var item in pessoas)
            {
                count++;
                if (count == pessoas.Count)
                {
                    //ultima Pessoa
                    paciente.pessoaId = item.id;
                }
            }

            if (ModelState.IsValid)
            {
                    
                await _service.Save(paciente);
                TempData["MensagemSucesso"] = "Paciente adicionado com sucesso";
                return RedirectToAction(nameof(Index));
            }
                ViewData["convenioId"] = new SelectList(await _convenioService.GetAll(), "id", "nome", "Selecione...");
                return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Paciente = await _service.FindById(id);
            ViewData["convenioId"] = new SelectList(await _convenioService.GetAll(), "id", "nome", "Selecione...");
            return View(Paciente);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PacienteDTO paciente)
        {
            if (id == null || paciente == null)
            {
                return NotFound();
            }

            //var pessoa = await _pessoaService.FindById(paciente.pessoa.id);
            //aciente.pessoaId = pessoa.id;
            if (ModelState.IsValid)
            {
                await _service.Save(paciente);
                TempData["MensagemSucesso"] = "Registro alterado com sucesso";
                return RedirectToAction(nameof(Index));
            }

            //ViewData["pessoaId"] = new SelectList(_pessoaService.GetAll(), "id", "nome", "Selecione...");
            ViewData["convenioId"] = new SelectList(await _convenioService.GetAll(), "id", "nome", "Selecione...");
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
