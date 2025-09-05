using FastEndpoints;
using Mapster;
using MediAppoint.Patient.Application.Commands.CreatePatient;
using MediAppoint.Patient.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace MediAppoint.Patient.Presentation.GetPatientEndpoint
{
    public class GetPatientById(ISender sender): Endpoint<GetPatientByIdDto,object>
    {
        public override void Configure()
        {
            Post("/patients/GetById");
            AllowAnonymous();
        }
        
        public override async Task HandleAsync(GetPatientByIdDto req, CancellationToken ct)
        {
    
            var query = new GetPatientByIdQuery(req.Id);

            var result = await sender.Send(query, ct);
            if (result.IsSuccess)
                await Send.OkAsync(result.Value);
            else
                await Send.ResultAsync(TypedResults.BadRequest(result.Error));
         
        }
    }
}
