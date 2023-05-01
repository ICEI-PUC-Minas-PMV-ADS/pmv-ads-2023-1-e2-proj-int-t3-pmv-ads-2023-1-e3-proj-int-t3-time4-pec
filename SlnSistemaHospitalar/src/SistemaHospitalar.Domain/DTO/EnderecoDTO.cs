using SistemaHospitalar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Domain.DTO
{
    public class EnderecoDTO
    {
        [Display(Name = "Código")]
        public int id { get; set; }
        public int pessoaId { get; set; }

        [Display(Name = "CEP")]
        public string cep { get; set; }

        [Display(Name = "Rua")]
        public string rua { get; set; }

        [Display(Name = "Nº")]
        public string numero { get; set; }

        [Display(Name = "Bairro")]
        public string bairro { get; set; }

        [Display(Name = "Cidade")]
        public string cidade { get; set; }

        [Display(Name = "UF")]
        public string uf { get; set; }

        public virtual Pessoa? pessoa { get; set; }
        


        public EnderecoDTO mapToDTO(Endereco endereco)
        {
            return new EnderecoDTO()
            {
                id = endereco.Id,
                pessoaId = endereco.PessoaId,
                cep = endereco.Cep,
                rua = endereco.Rua,
                numero = endereco.Numero,
                bairro = endereco.Bairro,
                cidade = endereco.Cidade,
                uf = endereco.UF,
            };
        }

        public Endereco mapToEntity()
        {
            return new Endereco()
            {
                Id = id,
                PessoaId = pessoaId,
                Cep = cep,
                Rua = rua,
                Numero = numero,
                Bairro = bairro,
                Cidade = cidade,
                UF = uf,
            };
        }
    }
}
