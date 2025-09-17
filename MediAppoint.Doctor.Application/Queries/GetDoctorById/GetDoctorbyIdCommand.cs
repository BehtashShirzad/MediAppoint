using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Doctor.Application.Queries.GetDoctorById
{
    public record GetDoctorbyIdCommand(Guid Id):IRequest<Result<GetDoctorByIdCommandResponse>>;
     
}
