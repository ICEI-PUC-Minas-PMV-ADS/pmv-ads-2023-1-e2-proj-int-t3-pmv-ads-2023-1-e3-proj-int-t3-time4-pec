using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SistemaHospitalar.Domain.DTO;

namespace SistemaHospitalar.Web.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //resgantando a sessao do user
            string sessao = HttpContext.Session.GetString("sessaoUsuario");

            //verificando se tem alguem logado
            if (sessao.IsNullOrEmpty())
            {
                return null;
            }

            //convertendo json em objeto
            PessoaDTO pessoa = JsonConvert.DeserializeObject<PessoaDTO>(sessao);

            return View(pessoa);
        }
    }
}
