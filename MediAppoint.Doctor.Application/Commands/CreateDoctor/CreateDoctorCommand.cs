using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Doctor.Application.Commands.CreateDoctor
{
    public record CreateDoctorCommand(string FullName, string UserName, string NationalCode, List<AddressModel> Addresses) :IRequest<Result<CreateDoctorCommandResponse>>;
    public record AddressModel(string Country, string StateCode, string StateName, string City, string Address1, string Address2, string ZipCode);
}
