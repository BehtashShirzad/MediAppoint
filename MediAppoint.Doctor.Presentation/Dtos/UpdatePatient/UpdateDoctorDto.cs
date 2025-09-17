using MediAppoint.Doctor.Presentation.Dtos.CreateDoctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MediAppoint.Doctor.Presenntation.Dtos.UpdatePatient
{
    public record UpdateDoctorDto(string FullName, string Username,List<AddressDto> Addresses)
    {
        [JsonIgnore]
        public Guid DoctorId { get; set; }
    };

}
