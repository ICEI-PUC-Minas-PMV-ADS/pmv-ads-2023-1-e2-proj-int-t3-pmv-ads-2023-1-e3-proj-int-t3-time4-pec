using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Domain.DTO
{
    public class ConvenioDTO
    {
        [Display(Name = "Código")]
        public int id { get; set; }

        [Display(Name = "Convênio")]
        public string nome { get; set; }

        public ConvenioDTO mapToDTO(Convenio convenio)
        {
            return new ConvenioDTO()
            {
                id = convenio.Id,
                nome = convenio.Nome
            };
        }

        public Convenio mapToEntity()
        {
            return new Convenio()
            {
                Id = id,
                Nome = nome
            };
        }
    }
}
