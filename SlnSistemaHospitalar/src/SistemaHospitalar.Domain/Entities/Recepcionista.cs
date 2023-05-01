using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Domain.Entities
{
    public class Recepcionista 
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public string Bloco { get; set; }
        public virtual Pessoa? Pessoa { get; set; }
    }
}
