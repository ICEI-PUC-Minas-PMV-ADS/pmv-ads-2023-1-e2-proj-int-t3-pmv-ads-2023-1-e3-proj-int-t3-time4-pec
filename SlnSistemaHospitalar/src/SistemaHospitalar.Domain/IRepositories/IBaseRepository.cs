using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Domain.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> FindById(int id);
        Task<int> Save(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
    }
}
