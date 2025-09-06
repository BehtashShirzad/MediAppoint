﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Domain
{
    public interface IUnitOfWork
    {
        //Task BeginAsync();
        //Task CommitAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
