using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Domain.Entities
{
    public class Prontuario
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public string QueixaPrincipal { get; set; }
        public string Descricao { get; set; }
        public string HistoricoFamiliar { get; set; }
        public string ExameFisico { get; set; }
        public string Condutas { get; set; }
        public string HipoteseDiagnostica { get; set; }
        public string Prescricao { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual Medico? Medico { get; set; }
        public virtual Paciente? Paciente { get; set; }
    }
}
