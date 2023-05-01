using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Domain.DTO;
using SistemaHospitalar.Domain.IServices;
using SistemaHospitalar.Web.Helper;
using SistemaHospitalar.Web.Models;

namespace SistemaHospitalar.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IPessoaService _service;
        private readonly ISessao _sessao;

        public LoginController(IPessoaService service, ISessao sessao)
        {
            _service = service;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            if (_sessao.BuscarSessao() != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Create()
        {
            if (_sessao.BuscarSessao() != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Entrar(LoginModel loginModel)
        {
            try
            {
                PessoaDTO pessoa = await _service.FindByLogin(loginModel.login);

                if (ModelState.IsValid)
                {
                    if (pessoa != null)
                    {
                        if (pessoa.ValidaSenha(loginModel.senha))
                        {
                            _sessao.CriarSessao(pessoa);
                            return RedirectToAction("Index", "Home");
                        }

                    }

                }

                TempData["MensagemErro"] = $"Ops, Login ou Senha inválidos. Tente novamente!";
                return View("Create");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, algo deu errado. Detalhes do problema: {ex}";
                return View();
            }
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessao();
            return RedirectToAction("Index", "Login");
        }
    }
}
