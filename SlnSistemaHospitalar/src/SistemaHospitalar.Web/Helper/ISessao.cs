using SistemaHospitalar.Domain.DTO;

namespace SistemaHospitalar.Web.Helper
{
    public interface ISessao
    {
        PessoaDTO BuscarSessao();
        void CriarSessao(PessoaDTO user);
        void RemoverSessao();
    }
}
