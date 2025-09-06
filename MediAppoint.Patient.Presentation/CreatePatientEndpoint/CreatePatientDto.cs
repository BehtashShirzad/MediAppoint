using MediAppoint.Patient.Application.Commands.CreatePatient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Presentation.CreatePatientEndpoint
{
    public record CreatePatientDto(string FullName,string UserName, string NationalCode,List<AddressDto> Addresses);
    public record CreatePatientResponseDto(Guid PatientId);
    public record AddressDto(string Country, string StateCode, string StateName, string City, string Address1, string Address2, string ZipCode);


}
