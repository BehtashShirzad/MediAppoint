using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Application
{
    public static class DependencyInjection
    {
        public static void  AddPatientApplicationServices(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            services.AddMediatR(_ => _.RegisterServicesFromAssembly(assembly));
           
        }
    }
}
