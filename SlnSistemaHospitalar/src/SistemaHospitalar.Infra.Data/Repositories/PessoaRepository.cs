using Microsoft.EntityFrameworkCore;
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
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        private readonly SQLServerContext _context;

        public PessoaRepository(SQLServerContext context)
            : base(context)
        {
        }

        public async Task<Pessoa> FindByLogin(string email)
        {
            return await _context.Pessoas.FirstOrDefaultAsync(p => p.Email == email);
        }
    }
}
