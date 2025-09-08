
using CSharpFunctionalExtensions;
using MediAppoint.Patient.Domain.Core;
using MediAppoint.Patient.Domain.ValueObjects;

using MediatR;
using SharedKernel.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Application.Commands.CreatePatient
{
    internal class CreatePatientCommandHandler (IIdGenerator<Guid> IdGenerator , IPatientRepository patientRepository,IUnitOfWork unitOfWork) : IRequestHandler<CreatePatientCommand, Result<CreatePatientCommandResponse>>
    {
        public async Task<Result<CreatePatientCommandResponse>> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {

            var patiendId = new PatientId(IdGenerator.Next());
           

            var addresses = request.Addresses
         .Select(item => Address.Create(
             item.Country,
             State.Create(item.StateCode, item.StateName),
             item.City,
             item.Address1,
             item.Address2,
             item.ZipCode))
         .ToList();

            var patinet =  Domain.Core.Patient.Create(patiendId, request.UserName, request.FullName,request.NationalCode, addresses);
            await patientRepository.AddAsync(patinet,cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            
            return new CreatePatientCommandResponse(patiendId.Value);
        }
    }
}
