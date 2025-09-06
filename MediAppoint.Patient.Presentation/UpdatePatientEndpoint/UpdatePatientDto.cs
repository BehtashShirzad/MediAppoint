using MediAppoint.Patient.Application.Commands.CreatePatient;
using MediAppoint.Patient.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Presentation.UpdatePatientEndpoint
{
    public record UpdatePatientDto(string FullName, string Username, string Password, List<AddressModel> Addresses) {
        [JsonIgnore]
        public Guid PatientId { get; set; }
    };
    
}
