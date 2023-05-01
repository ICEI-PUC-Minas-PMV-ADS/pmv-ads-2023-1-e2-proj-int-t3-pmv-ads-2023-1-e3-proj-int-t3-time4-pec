using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Domain.DTO;
using SistemaHospitalar.Domain.IServices;
using SistemaHospitalar.Infra.Data.Context;
using SistemaHospitalar.Web.Models;

namespace SistemaHospitalar.Web.Controllers
{
    public class ConveniosController : Controller
    {
        private readonly IConvenioService _service;

        public ConveniosController(IConvenioService service)
        {
            _service = service;
        }


        // GET: ConveniosController
        public async Task<IActionResult> Index()
        {
            var conv = await _service.GetAll();
            return View(conv);
        }

        // GET: ConveniosController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var conv = await _service.FindById(id);
            return View(conv);
        }

        // GET: ConveniosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConveniosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ConvenioDTO convenio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Save(convenio);
                    TempData["MensagemSucesso"] = "Convênio adicionado com sucesso";
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["MensagemErro"] = "Erro ao adicionar convênio";
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var conv = await _service.FindById(id);
            return View(conv);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ConvenioDTO convenio)
        {
            if(id == null || convenio == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _service.Save(convenio);
                TempData["MensagemSucesso"] = "Convênio alterado com sucesso";
                return RedirectToAction(nameof(Index));
            }

            TempData["MensagemErro"] = "Erro ao alterar convênio";
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
