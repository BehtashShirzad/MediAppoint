using Carter;
using Mapster;
using MediAppoint.Doctor.Application.Commands.CreateDoctor;
using MediAppoint.Doctor.Application.Commands.GetDoctorById;
using MediAppoint.Doctor.Application.Commands.UpdateDoctor;
using MediAppoint.Doctor.Presenntation.Dtos.UpdatePatient;
using MediAppoint.Doctor.Presentation.Dtos.CreateDoctor;
using MediAppoint.Doctor.Presentation.Dtos.GetPatientByIdDto;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SharedKernel.Presentation.ExtensionMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Doctor.Presentation
{
    public  class DoctorEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var gp = app.MapGroup("doctors");
            gp.MapGet("/{id:guid}", GetDoctorById);
            gp.MapPost("/",CreateDoctor);
            gp.MapPut("/",UpdateDoctor);
        }

        private async Task<IResult> UpdateDoctor([FromBody] UpdateDoctorDto dto, [FromServices]ISender sender, [FromServices]IHttpContextAccessor accessor)
        {
            dto.DoctorId = accessor.GetUserId();
        
            var cmd = dto.Adapt<UpdateDoctorCommand>();

            var rs=await sender.Send(cmd);
            if (rs.IsFailure)
                return TypedResults.BadRequest(rs.Error);
            return TypedResults.Ok();
        }

        [ProducesResponseType(typeof(CreateDoctorResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        private async Task<IResult> CreateDoctor([FromBody] CreateDoctorDto dto, [FromServices]ISender sender)
        {
            var mpd = dto.Adapt<CreateDoctorCommand>();
            var res=await sender.Send(mpd);
            if (res.IsSuccess)
                return TypedResults.Ok(res.Value);
            return TypedResults.BadRequest(res.Error);
        }

        [ProducesResponseType(typeof(CreateDoctorResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        private async Task<IResult> GetDoctorById([FromRoute]Guid Id,[FromServices]ISender sender)
        {
            var cmd = new GetDoctorbyIdCommand(Id);
            var rs= await sender.Send(cmd);
            if (rs.IsFailure)
                return TypedResults.BadRequest(rs.Error);
            var mpd = rs.Value.Adapt<GetDoctorByIdResponseDto>();
            return TypedResults.Ok(mpd);
        }
    }
}
