using CSharpFunctionalExtensions;
using MediAppoint.Patient.Domain.Core;
using MediAppoint.Patient.Domain.ValueObjects;
 
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Application.Queries
{
    public record GetPatientByIdQuery(Guid Id): IRequest<Result<Domain.Core.Patient>>;
    internal class GetPatientByIdQueryHandler (IPatientQueryRepository repository): IRequestHandler<GetPatientByIdQuery,Result<Domain.Core.Patient>>
    {
        public async Task<Result<Domain.Core.Patient>> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            var Id = new PatientId(request.Id);
            var data =  await repository.GetByIdAsync(  Id);
            if (data is null)
                return Result.Failure<Domain.Core.Patient>("Patient Not Found");
            return  data;
        }
    }
}
