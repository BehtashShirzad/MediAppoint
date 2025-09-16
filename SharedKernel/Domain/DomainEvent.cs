using SharedKernel.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Domain
{
    public abstract record DomainEvent  : IDomainEvent 
    {
        public  Guid  Id { get; }
        public DateTime OccurredOn { get; }

        protected DomainEvent() { 
        Id = Guid.NewGuid();
        }
        protected DomainEvent(Guid id )
        {
            Id = id;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
