using SistemaHospitalar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Domain.IRepositories
{
    public interface IMedicoRepository : IBaseRepository<Medico>
    {
        Task<Medico> FindByIdPessoa(int id);
    }
}
