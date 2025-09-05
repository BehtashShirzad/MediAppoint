using MediAppoint.Patient.Domain;
using MediAppoint.SharedKernel.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddPatientInfrastructureServices(this IServiceCollection services, IConfiguration configuration) { 
        SharedKernel.Infrastructure.DependencyInjection.AddInfrastructureServices(services, configuration);
            var constr = configuration.GetConnectionString("Patient");
            services.AddDbContextPool<PatientWriteContext>(options =>
            {
                options.UseSqlServer(constr);
            });
            services.AddDbContextPool<PatientReadContext>(options =>
            {
                options.UseSqlServer(constr);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
