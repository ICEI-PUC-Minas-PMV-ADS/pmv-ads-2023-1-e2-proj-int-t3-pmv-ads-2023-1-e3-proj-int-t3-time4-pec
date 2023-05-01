using SistemaHospitalar.Domain.DTO;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.IRepositories;
using SistemaHospitalar.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Application.Service.SQLServerServices
{
    public class ConvenioService : IConvenioService
    {
        private readonly IConvenioRepository _repository;

        public ConvenioService(IConvenioRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _repository.FindById(id);
            return await _repository.Delete(entity);
        }

        public async Task<List<ConvenioDTO>> GetAll()
        {
            List<ConvenioDTO> listaDTO = new List<ConvenioDTO>();

            var lista = await _repository.GetAll();
            foreach (var item in lista)
            {
                var conv = new ConvenioDTO();
                listaDTO.Add(conv.mapToDTO(item));
            }

            return listaDTO;
        }

        public async Task<int> Save(ConvenioDTO entity)
        {
            if(entity.id > 0)
            {
                return await _repository.Update(entity.mapToEntity());
            }
            else
            {
                return await _repository.Save(entity.mapToEntity());
            }
               
        }

        public async Task<ConvenioDTO> FindById(int id)
        {
            var conv = new ConvenioDTO();
            return conv.mapToDTO(await _repository.FindById(id));
        }
    }
}
