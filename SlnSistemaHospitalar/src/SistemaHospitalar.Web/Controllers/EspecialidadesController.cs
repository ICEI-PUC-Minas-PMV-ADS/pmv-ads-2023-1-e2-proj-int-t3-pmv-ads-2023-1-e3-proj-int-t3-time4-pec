using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Domain.DTO;
using SistemaHospitalar.Domain.IServices;
using SistemaHospitalar.Web.Models;

namespace SistemaHospitalar.Web.Controllers
{
    public class EspecialidadesController : Controller
    {
        private readonly IEspecialidadeMedicaService _service;

        public EspecialidadesController(IEspecialidadeMedicaService service)
        {
            _service = service;
        }


        // GET: EspecialidadesController
        public async Task<IActionResult> Index()
        {
            var conv = await _service.GetAll();
            return View(conv);
        }

        // GET: EspecialidadesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var esp = await _service.FindById(id);
            return View(esp);
        }

        // GET: EspecialidadesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EspecialidadesController/Create
        [HttpPost]
        public async Task<ActionResult> Create(EspecialidadeMedicaDTO especialidade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Save(especialidade);
                    TempData["MensagemSucesso"] = "Especialidade adicionada com sucesso";
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["MensagemErro"] = "Erro ao adicionar especialidade";
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var esp = await _service.FindById(id);
            return View(esp);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EspecialidadeMedicaDTO especialidade)
        {
            if (id == null || especialidade == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _service.Save(especialidade);
                TempData["MensagemSucesso"] = "Especialidade alterada com sucesso";
                return RedirectToAction(nameof(Index));
            }

            TempData["MensagemErro"] = "Erro ao alterar especialidade";
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
