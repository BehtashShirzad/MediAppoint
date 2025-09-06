using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Domain.Contracts
{
    public interface IIdGenerator< Tid>
    {
        public Tid Next();
    }
   
}
