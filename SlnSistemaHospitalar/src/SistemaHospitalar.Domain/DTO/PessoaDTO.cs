using SistemaHospitalar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Domain.DTO
{
    public class PessoaDTO
    {
        [Display(Name = "Código da Pessoa")]
        public int id { get; set; }

        [Display(Name = "Nome")]
        public string nome { get; set; }
        [Display(Name = "Sobrenome")]
        public string sobrenome { get; set; }

        [Display(Name = "CPF")]
        public string cpf { get; set; }

        [Display(Name = "RG")]
        public string rg { get; set; }

        [Display(Name = "Telefone")]
        public string telefone { get; set; }

        [Display(Name = "E-mail")]
        public string email { get; set; }
        public string senha { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime dataNascimento { get; set; }

        [Display(Name = "Naturalidade")]
        public string naturalidade { get; set; }

        [Display(Name = "Sexo")]
        public SexoEnum sexo { get; set; }

        [Display(Name = "Perfil")]
        public PerfilEnum perfil { get; set; }

        [Display(Name = "Data de Cadastro")]
        public DateTime createdOn { get; set; }

        public virtual ICollection<EnderecoDTO>? enderecos { get; set; }

        public PessoaDTO mapToDTO(Pessoa pessoa)
        {
            return new PessoaDTO()
            {
                id = pessoa.Id,
                nome = pessoa.Nome,
                sobrenome = pessoa.Sobrenome,
                cpf = pessoa.Cpf,
                rg = pessoa.Rg,
                telefone = pessoa.Telefone,
                email = pessoa.Email,
                senha = pessoa.Senha,
                dataNascimento = pessoa.DataNascimento,
                naturalidade = pessoa.Naturalidade,
                sexo = pessoa.Sexo,
                perfil = pessoa.Perfil,
                createdOn = pessoa.CreatedOn,
            };
        }

        public Pessoa mapToEntity()
        {
            return new Pessoa()
            {
                Id = id,
                Nome = nome,
                Sobrenome = sobrenome,
                Cpf = cpf,
                Rg = rg,
                Telefone = telefone,
                Email = email,
                Senha = senha,
                DataNascimento = dataNascimento,
                Naturalidade = naturalidade,
                Sexo = sexo,
                Perfil = perfil,
                CreatedOn = createdOn,
            };
        }

        public bool ValidaSenha(string senhaPessoa)
        {
            return senha.Equals(senhaPessoa);
        }
    }
}
