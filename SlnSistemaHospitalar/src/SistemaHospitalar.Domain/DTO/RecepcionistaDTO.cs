using SistemaHospitalar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Domain.DTO
{
    public class RecepcionistaDTO
    {
        [Display(Name = "Código")]
        public int id { get; set; }
        public int pessoaId { get; set; }
        [Display(Name = "Bloco")]
        public string bloco { get; set; }
        public virtual PessoaDTO? pessoa { get; set; }

        public RecepcionistaDTO mapToDTO(Recepcionista recepcionista)
        {
            return new RecepcionistaDTO()
            {
                id = recepcionista.Id,
                pessoaId = recepcionista.PessoaId,
                bloco = recepcionista.Bloco,
                
            };
        }

        public Recepcionista mapToEntity()
        {
            return new Recepcionista()
            {
                Id = id,
                PessoaId = pessoaId,
                Bloco = bloco,

            };
        }
    }
}
