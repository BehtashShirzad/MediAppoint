using MassTransit;
using MediAppoint.Patient.Application;
using MediAppoint.Patient.Domain;
using MediAppoint.Patient.Domain.Core;
using MediAppoint.Patient.Domain.Events;
 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SharedKernel.Application;
using SharedKernel.Domain;
using SharedKernel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
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
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPatientQueryRepository, QuerySqlRepository>();
           
            services.AddSingleton<IEventBus, EventBus>();
            
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("rabbitmq://localhost");  
                    cfg.ConfigureEndpoints(context);
                    
                });
            });
            services.AddDomainEventHandlers(ApplicationAssemblyReference.Assembly);
            services.AddDomainEventHandlersFactory();
        }


        public static void AddDomainEventHandlers(this IServiceCollection services, Assembly assembly)
        {
            var handlerTypes = assembly.GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .SelectMany(t => t.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDomainEventHandler<>))
                    .Select(i => new { HandlerType = t, InterfaceType = i }));

            foreach (var h in handlerTypes)
            {
                services.AddScoped(h.HandlerType);
                services.AddScoped(h.InterfaceType, h.HandlerType);
            }
        }


        public static void AddDomainEventHandlersFactory(this IServiceCollection services)
        {
            services.AddSingleton<IDomainEventHandlersFactory, DomainEventHandlersFactory>();
        }

    }
}
