using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SistemaHospitalar.Domain.DTO;

namespace SistemaHospitalar.Web.Filters
{
    public class PaginaParaPessoaLogada : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context) //esse metodo ele é acessado antes de qualquer coisa no projeto
        {
            //resgata a sessao do usuario
            string sessao = context.HttpContext.Session.GetString("sessaoUsuario");

            //se a sessao for nula, ent nao tem ninguem logado
            if (sessao.IsNullOrEmpty())
            {
                //vai redirecionar para pag inicial
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            }
            else
            {
                //convertendo json em objeto
                PessoaDTO pessoa = JsonConvert.DeserializeObject<PessoaDTO>(sessao);

                //se por acaso der algum problema na conversao
                if (pessoa == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
