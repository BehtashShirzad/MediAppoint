using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Doctor.Application.Commands.CreateDoctor
{
    internal class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, Result<CreateDoctorCommandResponse>>
    {
        public Task<Result<CreateDoctorCommandResponse>> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
           
        }
    }
}
