using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MediatR;
namespace MediAppoint.Patient.Application.Commands.CreatePatient
{
    public record CreatePatientCommand(string FullName,string NationalCode,string Country,string StateCode, string StateName, string City,string Address1,string Address2,string ZipCode):IRequest<Result<CreatePatientCommandResponse>>;
    
}
