using SistemaHospitalar.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace SistemaHospitalar.Domain.DTO
{
    public class EspecialidadeMedicaDTO
    {
        [Display(Name = "Código")]
        public int id { get; set; }
        [Display(Name = "Especialidade")]
        public string nome { get; set; }

        public EspecialidadeMedicaDTO mapToDTO(EspecialidadeMedica especialidade)
        {
            return new EspecialidadeMedicaDTO()
            {
                id = especialidade.Id,
                nome = especialidade.Nome,
            };
        }

        public EspecialidadeMedica mapToEntity()
        {
            return new EspecialidadeMedica()
            {
                Id = id,
                Nome = nome,
            };
        }
    }
}