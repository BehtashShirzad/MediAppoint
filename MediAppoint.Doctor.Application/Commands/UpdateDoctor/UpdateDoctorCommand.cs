using CSharpFunctionalExtensions;
using MediAppoint.Doctor.Application.Commands.CreateDoctor;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MediAppoint.Doctor.Application.Commands.UpdateDoctor
{
    public record UpdateDoctorCommand(Guid DoctorId, string FullName, string Username, List<AddressModel>? Addresses): IRequest<Result>;
    
}
