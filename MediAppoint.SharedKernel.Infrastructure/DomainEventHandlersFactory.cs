using MediAppoint.SharedKernel.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.SharedKernel.Infrastructure
{
    public class DomainEventHandlersFactory : IDomainEventHandlersFactory
    {
        public IEnumerable<IDomainEventHandler> GetHandlers(
            Type type,
            IServiceProvider serviceProvider,
            Assembly assembly
        )
        {
            var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(type);
            return assembly
                .GetTypes()
                .Where(t => t.IsAssignableTo(handlerType))
                .Select(handler => (IDomainEventHandler)serviceProvider.GetRequiredService(handler));
        }
    }
}
