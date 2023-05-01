using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaHospitalar.Domain.DTO;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.IServices;
using SistemaHospitalar.Web.Models;

namespace SistemaHospitalar.Web.Controllers
{
    public class MedicosController : Controller
    {
        private readonly IMedicoService _service;
        private readonly IPessoaService _pessoaService;
        private readonly IEspecialidadeMedicaService _especialidadeService;

        public MedicosController(IMedicoService service, IPessoaService pessoaService, IEspecialidadeMedicaService especialidadeService)
        {
            _service = service;
            _pessoaService = pessoaService;
            _especialidadeService = especialidadeService;
        }


        // GET: MedicosController
        public async Task<IActionResult> Index()
        {
            var medico = await _service.GetAll();
            return View(medico);
        }

        // GET: MedicosController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medico = await _service.FindById(id);
            return View(medico);
        }

        // GET: MedicosController/Create
        public async Task<ActionResult> Create()
        {
            ViewData["especialidadeId"] = new SelectList(await _especialidadeService.GetAll(), "id", "nome", "Selecione...");
            return View();
        }

        // POST: MedicosController/Create
        [HttpPost]

        public async Task<IActionResult> Create(MedicoDTO medico)
        {
            var pessoas = await _pessoaService.GetAll();

            int count = 0;
            foreach (var item in pessoas)
            {
                count++;
                if (count == pessoas.Count)
                {
                    //ultima Pessoa
                    medico.pessoaId = item.id;
                }
            }
            
            if (ModelState.IsValid)
            {

                await _service.Save(medico);
                TempData["MensagemSucesso"] = "Médico adicionado com sucesso";
                return RedirectToAction(nameof(Index));
            }
            ViewData["especialidadeId"] = new SelectList(await _especialidadeService.GetAll(), "id", "nome", "Selecione...");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medico = await _service.FindById(id);
            ViewData["especialidadeId"] = new SelectList(await _especialidadeService.GetAll(), "id", "nome", "Selecione...");
            return View(medico);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, MedicoDTO medico)
        {
            if (id == null || medico == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _service.Save(medico);
                TempData["MensagemSucesso"] = "Registro alterado com sucesso";
                return RedirectToAction(nameof(Index));
            }

            TempData["MensagemErro"] = "Erro ao alterar registro";
            return RedirectToAction(nameof(Index));

        }


        // POST: MedicosController/Delete/5
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
