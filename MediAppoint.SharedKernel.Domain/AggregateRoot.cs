using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.SharedKernel.Domain
{
    public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot
         where TId : IEquatable<TId>
    {
        private readonly List<IDomainEvent> _domainEvents = new();

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected AggregateRoot() { }

        protected AggregateRoot(TId id)
            : base(id) { }

        public void RaiseEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);

        public void ClearEvents() => _domainEvents.Clear();
    }
}
