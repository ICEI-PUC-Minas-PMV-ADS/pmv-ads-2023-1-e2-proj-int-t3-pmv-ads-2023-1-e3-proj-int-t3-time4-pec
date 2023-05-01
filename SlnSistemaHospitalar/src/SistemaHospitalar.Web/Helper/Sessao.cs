using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SistemaHospitalar.Domain.DTO;

namespace SistemaHospitalar.Web.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Sessao(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public PessoaDTO BuscarSessao()
        {
            string sessao = _httpContextAccessor.HttpContext.Session.GetString("sessaoUsuario");

            if (sessao.IsNullOrEmpty())
            {
                return null;
            }

            return JsonConvert.DeserializeObject<PessoaDTO>(sessao);
        }

        public void CriarSessao(PessoaDTO pessoa)
        {
            //convertendo pra json
            string pessoaConvertido = JsonConvert.SerializeObject(pessoa);

            _httpContextAccessor.HttpContext.Session.SetString("sessaoUsuario", pessoaConvertido);
            //key           //value
        }

        public void RemoverSessao()
        {
            _httpContextAccessor.HttpContext.Session.Remove("sessaoUsuario");
        }
    }
}
