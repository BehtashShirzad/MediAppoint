using CSharpFunctionalExtensions;
using MediAppoint.Patient.Domain.Core;
using MediAppoint.Patient.Domain.ValueObjects;
using MediAppoint.Patient.Infrastructure;
using MediAppoint.SharedKernel.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Application.Commands.CreatePatient
{
    internal class CreatePatientCommandHandler (IIdGenerator<Guid> IdGenerator ,PatientWriteContext context,IUnitOfWork unitOfWork) : IRequestHandler<CreatePatientCommand, Result<CreatePatientCommandResponse>>
    {
        public async Task<Result<CreatePatientCommandResponse>> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {

            var patiendId = new PatientId(IdGenerator.Next());
            var state = State.Create(request.StateCode, request.StateName); 
            var address = Address.Create(request.Country, state,request.City,request.Address1,request.Address2,request.ZipCode);
            var patinet =  Domain.Core.Patient.Create(patiendId,request.FullName,request.NationalCode,address);
            await context.AddAsync(patinet);
            await unitOfWork.SaveChangesAsync();
            //Store In db
            return new CreatePatientCommandResponse(patiendId.Value);
        }
    }
}
