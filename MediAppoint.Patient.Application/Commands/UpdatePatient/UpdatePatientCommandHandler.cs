using CSharpFunctionalExtensions;
using MediAppoint.Patient.Application.Errors;
using MediAppoint.Patient.Domain.Core;
using MediAppoint.Patient.Domain.ValueObjects;
using MediatR;
using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Application.Commands.UpdatePatient
{
    internal class UpdatePatientCommandHandler(IPatientRepository patientRepository,IUnitOfWork unitOfWork) : IRequestHandler<UpdatePatientCommand, Result<UpdatePatientCommandResponse>>
    {
        public async Task<Result<UpdatePatientCommandResponse>> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient =await patientRepository.GetByIdAsync(new (request.PatientId));
            if (patient is null)
                return Result.Failure<UpdatePatientCommandResponse>(PatientErrors.NotFound);

            if (request.Addresses is not null)
            {
                var addresses = request.Addresses
         .Select(item => Address.Create(
             item.Country,
             State.Create(item.StateCode, item.StateName),
             item.City,
             item.Address1,
             item.Address2,
             item.ZipCode))
         .ToList();
                patient!.UpdateAddress(addresses);
            }
            if(!string.IsNullOrEmpty(request.FullName))
                patient.UpdateFullName(request.FullName);
            if (!string.IsNullOrEmpty(request.Username))
                patient.UpdateUserName(request.Username);
            await patientRepository.UpdateAsync(patient);
            await unitOfWork.SaveChangesAsync();
            return Result.Success<UpdatePatientCommandResponse>(new());
        }
    }
}
