using SistemaHospitalar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Domain.DTO
{
    public class ProntuarioDTO
    {
        public int id { get; set; }
        public int pacienteId { get; set; }
        public int medicoId { get; set; }
        public string queixaPrincipal { get; set; }
        public string descricao { get; set; }
        public string historicoFamiliar { get; set; }
        public string exameFisico { get; set; }
        public string condutas { get; set; }
        public string hipoteseDiagnostica { get; set; }
        public string prescricao { get; set; }
        public DateTime createdOn { get; set; }

        public virtual MedicoDTO? medico { get; set; }
        public virtual PacienteDTO? paciente { get; set; }

        public ProntuarioDTO mapToDTO(Prontuario prontuario)
        {
            return new ProntuarioDTO()
            {
                id = prontuario.Id,
                pacienteId = prontuario.PacienteId,
                medicoId = prontuario.MedicoId,
                queixaPrincipal = prontuario.QueixaPrincipal,
                descricao = prontuario.Descricao,
                historicoFamiliar = prontuario.HistoricoFamiliar,
                exameFisico = prontuario.ExameFisico,
                condutas = prontuario.Condutas,
                hipoteseDiagnostica = prontuario.HipoteseDiagnostica,
                prescricao = prontuario.Prescricao,
                createdOn = prontuario.CreatedOn,

            };
        }

        public Prontuario mapToEntity()
        {
            return new Prontuario()
            {
                Id = id,
                PacienteId = pacienteId,
                MedicoId = medicoId,
                QueixaPrincipal = queixaPrincipal,
                Descricao = descricao,
                HistoricoFamiliar = historicoFamiliar,
                ExameFisico = exameFisico,
                Condutas = condutas,
                HipoteseDiagnostica = hipoteseDiagnostica,
                Prescricao = prescricao,
                CreatedOn = createdOn,

            };
        }
    }
}
