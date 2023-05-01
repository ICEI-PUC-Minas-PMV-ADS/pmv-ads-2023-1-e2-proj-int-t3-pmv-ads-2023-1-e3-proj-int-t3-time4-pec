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
    public class RecepcionistaService : IRecepcionistaService
    {
        private readonly IRecepcionistaRepository _repository;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public RecepcionistaService(IRecepcionistaRepository repository, IPessoaRepository pessoaRepository, IEnderecoRepository enderecoRepository)
        {
            _repository = repository;
            _pessoaRepository = pessoaRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _repository.FindById(id);
            var pessoa = await _pessoaRepository.FindById(entity.PessoaId);

            //deletando recepcionista
            await _repository.Delete(entity);

            var enderecos = await _enderecoRepository.GetAll();
            foreach (var item in enderecos)
            {
                if (item.PessoaId == pessoa.Id)
                {
                    await _enderecoRepository.Delete(item);
                }
            }

            return await _pessoaRepository.Delete(pessoa);
        }


        public async Task<RecepcionistaDTO> FindById(int id)
        {
            var r = new RecepcionistaDTO();
            var pessoadto = new PessoaDTO();
            var recepdto = r.mapToDTO(await _repository.FindById(id));
            recepdto.pessoa = pessoadto.mapToDTO(await _pessoaRepository.FindById(recepdto.pessoaId));
            return recepdto;
        }

        public async Task<List<RecepcionistaDTO>> GetAll()
        {
            List<RecepcionistaDTO> listaDTO = new List<RecepcionistaDTO>();

            var lista = await _repository.GetAll();
            foreach (var item in lista)
            {
                var rec = new RecepcionistaDTO();
                listaDTO.Add(rec.mapToDTO(item));
            }

            foreach (var recepcionista in listaDTO)
            {
                var pessoadto = new PessoaDTO();
                recepcionista.pessoa = pessoadto.mapToDTO(await _pessoaRepository.FindById(recepcionista.pessoaId));
            }

            return listaDTO;
        }

        public async Task<int> Save(RecepcionistaDTO entity)
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
