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
    public class ConvenioRepository : BaseRepository<Convenio>, IConvenioRepository
    {
        private readonly SQLServerContext _context;

        public ConvenioRepository(SQLServerContext context)
            :base(context)
        {

        }
    }
}
