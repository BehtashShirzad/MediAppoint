using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Doctor.Presentation.Dtos.CreateDoctor
{
    public record CreateDoctorDto(string FullName,string UserName, string NationalCode,List<AddressDto> Addresses);
    public record CreateDoctorResponseDto(Guid DoctorId);
    public record AddressDto(string Country, string StateCode, string StateName, string City, string Address1, string Address2, string ZipCode);


}
