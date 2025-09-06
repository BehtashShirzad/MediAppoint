using CSharpFunctionalExtensions;
using MediAppoint.Patient.Application.Commands.CreatePatient;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Application.Commands.UpdatePatient
{
    public record UpdatePatientCommand(Guid PatientId,string FullName,string Username,List<AddressModel>? Addresses):IRequest<Result<UpdatePatientCommandResponse>>;
    public record UpdatePatientCommandResponse();
    
}
