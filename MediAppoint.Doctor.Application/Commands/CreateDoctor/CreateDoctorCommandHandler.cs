using CSharpFunctionalExtensions;
using MediatR;
using SharedKernel.Domain.Contracts;
using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediAppoint.Doctor.Domain.ValueObjects;
using MediAppoint.Doctor.Domain.Contracts;

namespace MediAppoint.Doctor.Application.Commands.CreateDoctor
{
    internal class CreateDoctorCommandHandler (IIdGenerator<Guid> IdGenerator, IDoctorWriteRepository doctorRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateDoctorCommand, Result<CreateDoctorCommandResponse>>
    {
        public async Task<Result<CreateDoctorCommandResponse>> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var patiendId = new DoctorId(IdGenerator.Next());


            var addresses = request.Addresses
         .Select(item => Address.Create(
             item.Country,
             State.Create(item.StateCode, item.StateName),
             item.City,
             item.Address1,
             item.Address2,
             item.ZipCode))
         .ToList();

            var doctor = Domain.Core.Doctor.Create(patiendId, request.UserName, request.FullName, request.NationalCode, addresses,request.Degree);
            
            await doctorRepository.AddAsync(doctor, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return new CreateDoctorCommandResponse(doctor.Id.Value);

        }
    }
}
