using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Application
{
    public interface IEventBus
    {
        Task PublishAsync<TEvent>(TEvent @event) where TEvent : class;
    }
}
