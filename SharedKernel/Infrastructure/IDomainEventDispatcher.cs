
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Domain;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Infrastructure
{
    public interface IDomainEventsDispatcher
    {
        Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents,Assembly assembly, CancellationToken cancellationToken = default);
    }

   
}
