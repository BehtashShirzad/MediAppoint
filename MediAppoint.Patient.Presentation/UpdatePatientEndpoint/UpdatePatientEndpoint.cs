using FastEndpoints;
using Mapster;
using MediAppoint.Patient.Application.Commands.UpdatePatient;
using MediatR;
using Microsoft.AspNetCore.Http;
using SharedKernel.Presentation.ExtensionMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Presentation.UpdatePatientEndpoint
{
    internal class UpdatePatientEndpoint(ISender sender,IHttpContextAccessor contextAccessor):Endpoint<UpdatePatientDto>
    {
        public override void Configure()
        {
            Put("/patient");
           
        }
        public override async Task HandleAsync(UpdatePatientDto req, CancellationToken ct)
        {
          //  req.PatientId =Guid.Parse("01991DF3-CA7F-50A9-5004-06A26DE5CDC3");
            req.PatientId= contextAccessor.GetUserId();
            var cmd = req.Adapt<UpdatePatientCommand>();
            
            var result =await sender.Send(cmd);
            if(result.IsSuccess)
            {
                await Send.OkAsync();
            }
            else
            {
                await Send.ResultAsync(TypedResults.BadRequest(result.Error));
            }


        }
    }
}
