using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Application;
using SharedKernel.Domain.Contracts;
using SharedKernel.Infrastructure.Contracts;
using SharedKernel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MediAppoint.Doctor.Domain.Contracts;
using MassTransit;
using MediAppoint.Doctor.Application;
using Microsoft.EntityFrameworkCore;

namespace MediAppoint.Doctor.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddDoctorInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            SharedKernel.Infrastructure.DependencyInjection.AddInfrastructureServices(services, configuration);

            var constr = configuration.GetConnectionString("Doctor");
            services.AddDbContextPool<DoctorWriteDbContext>(options =>
            {
                options.UseSqlServer(constr);
            });
            services.AddDbContextPool<DoctorReadDbContext>(options =>
            {
                options.UseSqlServer(constr);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDoctorWriteRepository, DoctorWriteSqlRepository>();
            services.AddScoped<IDoctorQueryRepository, DoctorReadSqlRepository>();

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
