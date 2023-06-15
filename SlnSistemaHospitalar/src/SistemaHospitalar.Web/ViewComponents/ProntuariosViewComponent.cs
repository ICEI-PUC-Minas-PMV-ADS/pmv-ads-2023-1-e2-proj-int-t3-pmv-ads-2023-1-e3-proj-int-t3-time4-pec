using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.IRepositories;
using SistemaHospitalar.Domain.Repositories;
using SistemaHospitalar.Infra.Data.Context;

namespace SistemaHospitalar.Web.ViewComponents
{
    public class ProntuariosViewComponent : ViewComponent
    {
        private readonly IProntuarioRepository _prontuarioRepository;
        public ProntuariosViewComponent(IProntuarioRepository prontuarioRepository)
        {
            _prontuarioRepository = prontuarioRepository;
        }

        public IViewComponentResult Invoke()
        {
            var prontuarios = _prontuarioRepository.GetAll();
            return View(prontuarios);
        }
    }
}
