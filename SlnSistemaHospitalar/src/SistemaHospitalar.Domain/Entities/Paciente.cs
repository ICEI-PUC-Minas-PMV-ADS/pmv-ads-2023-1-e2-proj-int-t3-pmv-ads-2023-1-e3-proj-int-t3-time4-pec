using SistemaHospitalar.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Domain.Entities
{
    public class Paciente
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public int ConvenioId { get; set; }
        public SituacaoEnum Situacao { get; set; }
        public virtual Convenio? Convenio { get; set; }

        public Pessoa? Pessoa { get; set; }
        //public ICollection<Prontuario>? Prontuarios { get; set; }
    }
}
