using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Domain
{
    
    public abstract class EntityBase
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

        protected void RaiseEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
        public void ClearDomainEvents() => _domainEvents.Clear();
    }

   
    public abstract class Entity<TId> : EntityBase, IEntity<TId>, IEquatable<Entity<TId>>
        where TId : IEquatable<TId>
    {
        public TId Id { get; init; }

        protected Entity() => Id = default!;
        protected Entity(TId id) => Id = id;

        public bool Equals(Entity<TId>? other) => Equals(other as object);

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;
            return Id.Equals(((Entity<TId>)obj).Id);
        }

        public static bool operator ==(Entity<TId> left, Entity<TId> right)
            => Equals(left, right);

        public static bool operator !=(Entity<TId> left, Entity<TId> right)
            => !Equals(left, right);

        public override int GetHashCode() => Id.GetHashCode() ^ 31;
    }

}
