using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.IRepositories;
using SistemaHospitalar.Infra.Data.Context;
using SistemaHospitalar.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Domain.Repositories
{
    public class MedicoRepository : BaseRepository<Medico>, IMedicoRepository
    {
        private readonly SQLServerContext _context;

        public MedicoRepository(SQLServerContext context)
            :base(context)
        {
        }

        public async Task<Medico> FindByIdPessoa(int id)
        {
            return _context.Medicos.FirstOrDefault(m => m.PessoaId == id);
        }
    }
}
