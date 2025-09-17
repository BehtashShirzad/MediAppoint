using CSharpFunctionalExtensions;
using MediAppoint.Doctor.Application.Errors;
using MediAppoint.Doctor.Domain.Contracts;
using MediAppoint.Doctor.Domain.Core;
using MediAppoint.Doctor.Domain.ValueObjects;
using MediatR;
using SharedKernel.Domain;
using SharedKernel.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Doctor.Application.Commands.UpdateDoctor
{
    internal class UpdateDoctorCommandHandler(IUnitOfWork unitOfWork,IDoctorWriteRepository writeRepository) : IRequestHandler<UpdateDoctorCommand,Result>
    {
        public async Task<Result> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var patient = await writeRepository.GetByIdAsync(new(request.DoctorId));
            if (patient is null)
                return Result.Failure<Result>(DoctorErrors.NotFound);

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
            if (!string.IsNullOrEmpty(request.FullName))
                patient.UpdateFullName(request.FullName);
            if (!string.IsNullOrEmpty(request.Username))
                patient.UpdateUserName(request.Username);
            await writeRepository.UpdateAsync(patient);
            await unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
    }
}
