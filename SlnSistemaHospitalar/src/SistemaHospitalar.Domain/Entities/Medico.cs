using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Domain.Entities
{
    public class Medico
    {
        public int Id { get; set; }
        public int EspecialidadeId { get; set; }
        public int PessoaId { get; set; }
        public string CRM { get; set; }

        public virtual Pessoa? Pessoa { get; set; }
        public virtual EspecialidadeMedica? Especialidade { get; set; }
    }

}
