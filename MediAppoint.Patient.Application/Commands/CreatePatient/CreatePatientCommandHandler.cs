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
            List<Address> addresses = new();
            
            foreach (var item in request.Addresses)
            {
                addresses.Add(Address.Create(item.Country, State.Create(item.StateCode, item.StateName), item.City, item.Address1, item.Address2, item.ZipCode));
            }
           
            var patinet =  Domain.Core.Patient.Create(patiendId,request.FullName,request.NationalCode, addresses);
            await context.AddAsync(patinet);
            await unitOfWork.SaveChangesAsync();
            //Store In db
            return new CreatePatientCommandResponse(patiendId.Value);
        }
    }
}
