using Microsoft.EntityFrameworkCore;
using SistemaHospitalar.Domain.IRepositories;
using SistemaHospitalar.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T: class
    {
        private readonly SQLServerContext _context;

        public BaseRepository(SQLServerContext context)
        {
            _context = context;
        }

        public async Task<int> Delete(T entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<T> FindById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<int> Save(T entity)
        {
            _context.Set<T>().Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync();
        }

        //public T TheLast()
        //{
        //   return _context.Set<T>().Last();
        //}
    }
}
