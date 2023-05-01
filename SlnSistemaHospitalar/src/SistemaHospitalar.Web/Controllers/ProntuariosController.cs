using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaHospitalar.Domain.DTO;
using SistemaHospitalar.Domain.IServices;
using SistemaHospitalar.Web.Helper;
using SistemaHospitalar.Web.Models;

namespace SistemaHospitalar.Web.Controllers
{
    public class ProntuariosController : Controller
    {
        private readonly IProntuarioService _service;
        private readonly IPessoaService _pessoaService;
        private readonly IMedicoService _medicoService;
        private readonly ISessao _sessao;

        public ProntuariosController(IProntuarioService service, IPessoaService pessoaService, ISessao sessao, IMedicoService medicoService)
        {
            _service = service;
            _pessoaService = pessoaService;
            _sessao = sessao;
            _medicoService = medicoService;
        }


        // GET: ProntuariosController
        public ActionResult Index()
        {
            var prontuario = _service.GetAll();
            return View(prontuario);
        }

        // GET: ProntuariosController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prontuario = await _service.FindById(id);
            return View(prontuario);
        }

        // GET: ProntuariosController/Create
        public async Task<PartialViewResult> Create()
        {
            ViewData["pessoaId"] = new SelectList(await _pessoaService.GetAll(), "id", "nome", "Selecione...");
            return PartialView();
        }

        // POST: ProntuariosController/Create
        [HttpPost]

        public async Task<JsonResult> Create(ProntuarioDTO prontuario)
        {
            var retDel = new ReturnJson
            {
                status = "Error",
                code = "400"
            };

            var pessoa = _sessao.BuscarSessao();
            var medico = await _medicoService.FindByIdPessoa(pessoa.id);
            prontuario.medicoId = medico.id;
            prontuario.createdOn = DateTime.Now;
            if (ModelState.IsValid)
            {

                await _service.Save(prontuario);
                TempData["MensagemSucesso"] = "Prontuário adicionado com sucesso";
                retDel = new ReturnJson
                {
                    status = "Success",
                    code = "200"
                };
            }
            ViewData["pessoaId"] = new SelectList(await _pessoaService.GetAll(), "id", "nome", "Selecione...");
            return Json(retDel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prontuario = await _service.FindById(id);
            //ViewData["pessoaId"] = new SelectList(_pessoaService.GetAll(), "id", "nome", "Selecione...");
            return View(prontuario);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProntuarioDTO prontuario)
        {
            if (id == null || prontuario == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _service.Save(prontuario);
                TempData["MensagemSucesso"] = "Registro alterado com sucesso";
                return RedirectToAction(nameof(Index));
            }

            //ViewData["pessoaId"] = new SelectList(_pessoaService.GetAll(), "id", "nome", "Selecione...");
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
