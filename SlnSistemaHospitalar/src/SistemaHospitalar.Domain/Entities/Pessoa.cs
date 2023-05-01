using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Domain.Entities
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Naturalidade { get; set; }
        public SexoEnum Sexo { get; set; }
        public PerfilEnum Perfil { get; set; }

        
        public DateTime CreatedOn { get; set; }

        public ICollection<Endereco>? Enderecos { get; set; }
    }
}
