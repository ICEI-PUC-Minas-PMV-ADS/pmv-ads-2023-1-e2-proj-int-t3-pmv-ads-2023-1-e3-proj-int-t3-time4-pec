using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Domain.DTO;
using SistemaHospitalar.Domain.IServices;
using SistemaHospitalar.Web.Models;
using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Web.Controllers
{
    public class PessoasController : Controller
    {
        private readonly IPessoaService _service;

        public PessoasController(IPessoaService service)
        {
            _service = service;
        }


        // GET: PessoasController
        public async Task<IActionResult> Index()
        {
            var pessoa = await _service.GetAll();
            return View(pessoa);
        }

        // GET: PessoasController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _service.FindById(id);
            return View(pessoa);
        }

        // GET: PessoasController/Create
        public PartialViewResult Create()
        {
            return PartialView();
        }

        // POST: PessoasController/Create
        [HttpPost]
        public async Task<IActionResult> Create(PessoaDTO pessoa)
        {

            pessoa.createdOn = DateTime.Now;
            var retDel = new ReturnJson
            {
                status = "Error",
                code = "400"
            };
            if (ModelState.IsValid)
            {
                await _service.Save(pessoa);
                retDel = new ReturnJson
                {
                    status = "Success",
                    code = "200"
                };
            }

            return Json(retDel);
        }

        public async Task<PartialViewResult> Edit(int id)
        {

            var pessoa = await _service.FindById(id);
            return PartialView(pessoa);
        }

        [HttpPost]
        public async Task<JsonResult> Edit(int id, PessoaDTO pessoa)
        {
            var retDel = new ReturnJson
            {
                status = "Error",
                code = "400"
            };
            if (ModelState.IsValid)
            {
                await _service.Save(pessoa);
                retDel = new ReturnJson
                {
                    status = "Success",
                    code = "200"
                };
            }

            return Json(retDel);

        }

    }
}
