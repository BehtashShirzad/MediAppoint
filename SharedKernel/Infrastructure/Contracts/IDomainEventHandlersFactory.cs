using SharedKernel.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Infrastructure.Contracts
{
    public interface IDomainEventHandlersFactory
    {
        IEnumerable<IDomainEventHandler> GetHandlers(
            Type type,
            IServiceProvider serviceProvider,
            Assembly assembly
        );
    }
}
