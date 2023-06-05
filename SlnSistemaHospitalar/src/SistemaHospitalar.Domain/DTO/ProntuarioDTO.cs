using SistemaHospitalar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Domain.DTO
{
    public class ProntuarioDTO
    {
        [Display(Name = "Código da Pessoa")]
        public int id { get; set; }

        [Display(Name = "Código do Paciente")]
        public int pacienteId { get; set; }

        [Display(Name = "Código do Médico")]
        public int medicoId { get; set; }

        [Display(Name = "Queixa")]
        public string queixaPrincipal { get; set; }

        [Display(Name = "Descrição")]
        public string descricao { get; set; }

        [Display(Name = "Histórico familiar")]
        public string historicoFamiliar { get; set; }

        [Display(Name = "Exame físico")]
        public string exameFisico { get; set; }

        [Display(Name = "Conduta")]
        public string conduta { get; set; }

        [Display(Name = "Hipótese Diagnóstica")]
        public string hipoteseDiagnostica { get; set; }

        [Display(Name = "Prescrição")]
        public string prescricao { get; set; }

        [Display(Name = "Data do Prontuário")]
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
                /*conduta = prontuario.Conduta,*/
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
                /*Conduta = conduta,*/
                HipoteseDiagnostica = hipoteseDiagnostica,
                Prescricao = prescricao,
                CreatedOn = createdOn,

            };
        }
    }
}
