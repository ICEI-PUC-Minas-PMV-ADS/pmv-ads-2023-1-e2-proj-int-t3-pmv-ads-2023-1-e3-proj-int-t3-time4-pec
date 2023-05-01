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
    public class EspecialidadeMedicaService : IEspecialidadeMedicaService
    {
        private readonly IEspecialidadeMedicaRepository _repository;

        public EspecialidadeMedicaService(IEspecialidadeMedicaRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _repository.FindById(id);
            return await _repository.Delete(entity);
        }


        public async Task<EspecialidadeMedicaDTO> FindById(int id)
        {
            var esp = new EspecialidadeMedicaDTO();
            return esp.mapToDTO(await _repository.FindById(id));
        }

        public async Task<List<EspecialidadeMedicaDTO>> GetAll()
        {
            List<EspecialidadeMedicaDTO> listaDTO = new List<EspecialidadeMedicaDTO>();

            var lista = await _repository.GetAll();
            foreach (var item in lista)
            {
                var esp = new EspecialidadeMedicaDTO();
                listaDTO.Add(esp.mapToDTO(item));
            }

            return listaDTO;
        }

        public async Task<int> Save(EspecialidadeMedicaDTO entity)
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
