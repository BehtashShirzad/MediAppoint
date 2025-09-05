using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.SharedKernel.Domain
{
    public abstract class Entity<TId> : IEntity<TId>, IEquatable<Entity<TId>>
       where TId : IEquatable<TId>
    {
        public TId Id { get; init; }

        protected Entity()
        {
            Id = default!;
        }

        protected Entity(TId id)
        {
            Id = id;
        }

        public bool Equals(Entity<TId>? other)
        {
            return Equals(other as object);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            var otherObject = (Entity<TId>)obj;

            return Id.Equals(otherObject.Id);
        }

        public static bool operator ==(Entity<TId> left, Entity<TId> right)
        {
            if (Equals(left, null))
            {
                return Equals(right, null);
            }
            else
            {
                return left.Equals(right);
            }
        }

        public static bool operator !=(Entity<TId> left, Entity<TId> right)
        {
            return !(left == right);
        }

        public override int GetHashCode() => Id.GetHashCode() ^ 31;
    }
}
