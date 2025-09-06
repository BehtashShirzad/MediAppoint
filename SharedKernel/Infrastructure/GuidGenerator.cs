
using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Infrastructure
{
    internal class GuidGenerator : IIdGenerator<Guid>
    {
        public Guid Next()
        {
            return Ulid.NewUlid().ToGuid();
        }
    }
}
