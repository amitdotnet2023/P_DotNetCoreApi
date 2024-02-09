using P_DotNetCoreApi_DAL.DBContextF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_DotNetCoreApi_DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DBContextFiledb _dbContext;
        public UnitOfWork(DBContextFiledb dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _dbContext.Dispose();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
