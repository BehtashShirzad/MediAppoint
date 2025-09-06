using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Domain.Contracts
{
    public interface IEntity<out TId>
        where TId : notnull
    {
        TId Id { get; }
    }
}
