using SistemaHospitalar.Domain.DTO;
using SistemaHospitalar.Domain.Entities;
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
    public class ProntuarioService : IProntuarioService
    {
        private readonly IProntuarioRepository _repository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMedicoRepository _medicoRepository;

        public ProntuarioService(IProntuarioRepository repository, IPacienteRepository pacienteRepository, IMedicoRepository medicoRepository)
        {
            _repository = repository;
            _pacienteRepository = pacienteRepository;
            _medicoRepository = medicoRepository;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _repository.FindById(id);
            return await _repository.Delete(entity);
        }


        public async Task<ProntuarioDTO> FindById(int id)
        {
            var pr = new ProntuarioDTO();
            return pr.mapToDTO(await _repository.FindById(id));
        }

        public async Task<List<ProntuarioDTO>> GetAll()
        {
            List<ProntuarioDTO> listaDTO = new List<ProntuarioDTO>();

            var lista = await _repository.GetAll();
            foreach (var item in lista)
            {
                var pront = new ProntuarioDTO();
                listaDTO.Add(pront.mapToDTO(item));
            }

            foreach (var prontuario in listaDTO)
            {
                var pacientedto = new PacienteDTO();
                var medicodto = new MedicoDTO();
                prontuario.paciente = pacientedto.mapToDTO(await _pacienteRepository.FindById(prontuario.pacienteId));
                prontuario.medico = medicodto.mapToDTO(await _medicoRepository.FindById(prontuario.pacienteId));

            }

            return listaDTO;
        }

        public async Task<int> Save(ProntuarioDTO entity)
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
