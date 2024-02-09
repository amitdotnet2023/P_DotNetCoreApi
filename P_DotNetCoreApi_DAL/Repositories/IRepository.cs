using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_DotNetCoreApi_DAL.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int Id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int Id);
    }
}
