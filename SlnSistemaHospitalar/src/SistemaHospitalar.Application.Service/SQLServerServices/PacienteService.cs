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
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _repository;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IConvenioRepository _convenioRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public PacienteService(IPacienteRepository repository, IPessoaRepository pessoaRepository, IConvenioRepository convenioRepository, IEnderecoRepository enderecoRepository)
        {
            _repository = repository;
            _pessoaRepository = pessoaRepository;
            _convenioRepository = convenioRepository;
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
                if(item.PessoaId == pessoa.Id)
                {
                    await _enderecoRepository.Delete(item);
                }
            }

            return await _pessoaRepository.Delete(pessoa);   
        }

        public async Task<PacienteDTO> FindById(int id)
        {
            var p = new PacienteDTO();
            var pessoadto = new PessoaDTO();
            var conv = new ConvenioDTO();
           
            var pacdto = p.mapToDTO(await _repository.FindById(id));
            pacdto.pessoa = pessoadto.mapToDTO(await _pessoaRepository.FindById(pacdto.pessoaId));
            pacdto.convenio = conv.mapToDTO(await _convenioRepository.FindById(pacdto.convenioId));
            return pacdto;
        }

        public async Task<List<PacienteDTO>> GetAll()
        {
            List<PacienteDTO> listaDTO = new List<PacienteDTO>();

            var lista = await _repository.GetAll();
            foreach (var item in lista)
            {
                var pac = new PacienteDTO();
                listaDTO.Add(pac.mapToDTO(item));
            }

            foreach (var paciente in listaDTO)
            {
                var pessoadto = new PessoaDTO();
                var conv = new ConvenioDTO();
                paciente.pessoa = pessoadto.mapToDTO(await _pessoaRepository.FindById(paciente.pessoaId));
                paciente.convenio = conv.mapToDTO(await _convenioRepository.FindById(paciente.convenioId));
            }

            return listaDTO;
        }

        public async Task<int> Save(PacienteDTO entity)
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
