using SistemaHospitalar.Domain.DTO;
using SistemaHospitalar.Domain.IRepositories;
using SistemaHospitalar.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Application.Service.SQLServerServices
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _repository;

        public PessoaService(IPessoaRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _repository.FindById(id);
            return await _repository.Delete(entity);
        }


        public async Task<PessoaDTO> FindById(int id)
        {
            var pessoa = new PessoaDTO();
            return pessoa.mapToDTO(await _repository.FindById(id));
        }

        public async Task<PessoaDTO> FindByLogin(string email)
        {
            var pessoa = new PessoaDTO();
            return pessoa.mapToDTO(await _repository.FindByLogin(email));
        }

        public async Task<List<PessoaDTO>> GetAll()
        {
            List<PessoaDTO> listaDTO = new List<PessoaDTO>();

            var lista = await _repository.GetAll();
            foreach (var item in lista)
            {
                var pessoa = new PessoaDTO();
                listaDTO.Add(pessoa.mapToDTO(item));
            }

            return listaDTO;
               
        }

        public async Task<int> Save(PessoaDTO entity)
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

        //public PessoaDTO GetTheLast()
        //{
        //    var pessoa = new PessoaDTO();
        //    return pessoa.mapToDTO(_repository.GetTheLast());
        //}
    }
}
