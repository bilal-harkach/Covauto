using Covauto.Domain.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoekenAPI.Domain
{
    public static class ServiceConfiguration
    {
        public static void RegisterServices(IServiceCollection services, string connectionString)
        {
            services.AddSqlite<AutosContext>(connectionString);
        }
    }
}
