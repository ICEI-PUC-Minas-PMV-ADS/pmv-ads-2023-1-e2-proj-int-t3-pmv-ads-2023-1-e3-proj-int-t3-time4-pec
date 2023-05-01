using SistemaHospitalar.Domain.DTO;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.IRepositories;
using SistemaHospitalar.Domain.IServices;
using SistemaHospitalar.Domain.Repositories;
using SistemaHospitalar.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Application.Service.SQLServerServices
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _repository;
        private readonly IPessoaService _pessoaRepository;
        private readonly IEspecialidadeMedicaService _especialidadeService;
        private readonly IEnderecoRepository _enderecoRepository;

        public MedicoService(IMedicoRepository repository, IPessoaService pessoaRepository, IEspecialidadeMedicaService especialidadeService, IEnderecoRepository enderecoRepository)
        {
            _repository = repository;
            _pessoaRepository = pessoaRepository;
            _especialidadeService = especialidadeService;
            _enderecoRepository = enderecoRepository;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _repository.FindById(id);
            var pessoa = await _pessoaRepository.FindById(entity.PessoaId);
            await _repository.Delete(entity);

            var enderecos = await _enderecoRepository.GetAll();
            foreach (var item in enderecos)
            {
                if (item.PessoaId == pessoa.id)
                {
                    await _enderecoRepository.Delete(item);
                }
            }

            return await _pessoaRepository.Delete(pessoa.id);
        }


        public async Task<MedicoDTO> FindById(int id)
        {
            var med = new MedicoDTO();
            var meddto = med.mapToDTO(await _repository.FindById(id));
            meddto.pessoa = await _pessoaRepository.FindById(meddto.pessoaId);
            meddto.especialidade = await _especialidadeService.FindById(meddto.especialidadeId);
            return meddto;
        }

        public async Task<MedicoDTO> FindByIdPessoa(int id)
        {
            var medico = new MedicoDTO();
            return medico.mapToDTO(await _repository.FindByIdPessoa(id));
        }

        public async Task<List<MedicoDTO>> GetAll()
        {
            List<MedicoDTO> listaDTO = new List<MedicoDTO>();

            var lista = await _repository.GetAll();
            foreach (var item in lista)
            {
                var med = new MedicoDTO();
                listaDTO.Add(med.mapToDTO(item));
            }

            foreach (var medico in listaDTO)
            {
                medico.pessoa = await _pessoaRepository.FindById(medico.pessoaId);
                medico.especialidade = await _especialidadeService.FindById(medico.especialidadeId);
            }

            return listaDTO;
        }

        public async Task<int> Save(MedicoDTO entity)
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
    }
}
