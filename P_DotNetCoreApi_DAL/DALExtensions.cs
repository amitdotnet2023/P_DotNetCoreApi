using Microsoft.Extensions.DependencyInjection;
using P_DotNetCoreApi_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_DotNetCoreApi_DAL
{
    public static class DALExtensions
    {
        public static IServiceCollection AddDataAccessExtensions(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
