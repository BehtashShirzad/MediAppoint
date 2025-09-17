using CSharpFunctionalExtensions;
using MediAppoint.Doctor.Domain.Contracts;
using MediAppoint.Doctor.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Doctor.Application.Queries.GetDoctorById
{
    internal class GetDoctorByIdCommandHandler(IDoctorQueryRepository doctorQuery) : IRequestHandler<GetDoctorbyIdCommand, Result<GetDoctorByIdCommandResponse>>
    {
        public async Task<Result<GetDoctorByIdCommandResponse>> Handle(GetDoctorbyIdCommand request, CancellationToken cancellationToken)
        {
            var doctorId = new DoctorId(request.Id);
            var result = await doctorQuery.GetByIdAsync(doctorId);
            return new GetDoctorByIdCommandResponse(result?.Name?.Value);
        }
    }
}
