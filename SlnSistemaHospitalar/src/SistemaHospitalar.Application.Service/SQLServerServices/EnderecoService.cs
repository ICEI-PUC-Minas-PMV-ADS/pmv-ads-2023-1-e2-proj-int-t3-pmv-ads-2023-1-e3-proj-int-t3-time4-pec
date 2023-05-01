using SistemaHospitalar.Domain.DTO;
using SistemaHospitalar.Domain.IRepositories;
using SistemaHospitalar.Domain.IServices;
using SistemaHospitalar.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Application.Service.SQLServerServices
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _repository;
        private readonly IPessoaRepository _pessoaRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository, IPessoaRepository pessoaRepository)
        {
            _repository = enderecoRepository;
            _pessoaRepository = pessoaRepository;   
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _repository.FindById(id);
            return await _repository.Delete(entity);
        }


        public async Task<EnderecoDTO> FindById(int id)
        {
            var end = new EnderecoDTO();
            return end.mapToDTO(await _repository.FindById(id));
        }

        public async Task<List<EnderecoDTO>> GetAll()
        {
            List<EnderecoDTO> listaDTO = new List<EnderecoDTO>();

            var lista = await _repository.GetAll();
            foreach (var item in lista)
            {
                var pac = new EnderecoDTO();
                listaDTO.Add(pac.mapToDTO(item));
            }

            return listaDTO;

        }

        public async Task<List<EnderecoDTO>> ListaEndereco(int id)
        {
            List<EnderecoDTO> listaDTO = new List<EnderecoDTO>();

            var lista = await _repository.GetAll();
            foreach (var item in lista)
            {
                if(item.PessoaId == id)
                {
                    var pac = new EnderecoDTO();
                    listaDTO.Add(pac.mapToDTO(item));
                }
                
            }

            return listaDTO;

        }

        public async Task<int> Save(EnderecoDTO entity)
        {

            if (entity.id > 0)
            {
                return await _repository.Update(entity.mapToEntity());
            }
            else
            {
                return await _repository.Save(entity.mapToEntity());
            }
        }
    }
}
