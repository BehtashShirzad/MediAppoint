using FastEndpoints;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Presentation
{
    public static class DependencyInjection
    {
        public static void AddPatientPresentationServices(this IServiceCollection services)
        {
          services.AddFastEndpoints();
        }
    }
}
