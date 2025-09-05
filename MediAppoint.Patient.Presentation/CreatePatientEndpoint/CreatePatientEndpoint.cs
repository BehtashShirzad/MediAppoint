using FastEndpoints;
using Mapster;
using MediAppoint.Patient.Application.Commands.CreatePatient;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Presentation.CreatePatientEndpoint
{
    public class CreatePatientEndpoint(ISender sender): Endpoint<CreatePatientDto,CreatePatientResponseDto>
    {
        public override void Configure()
        {
            Post("/patient");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreatePatientDto req, CancellationToken ct)
        {
            var cmd = req.Adapt<CreatePatientCommand>();
            var result =await sender.Send(cmd,ct);
            if(result.IsSuccess)
                 await Send.OkAsync(new CreatePatientResponseDto(result.Value.PatiendId));
         else
                await Send.ErrorsAsync();
        }
    }
}
