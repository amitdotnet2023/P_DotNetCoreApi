using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using P_DotNetCoreApi_BAL.Interfaces;
using P_DotNetCoreApi_BAL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_DotNetCoreApi_BAL
{
    public static class BALExtensions
    {
        public static IServiceCollection AddBusinessAccessExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITodoMasterServices, TodoMasterServices>();
            return services;
        }
    }
}
