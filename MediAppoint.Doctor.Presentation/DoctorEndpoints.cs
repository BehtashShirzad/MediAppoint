using Carter;
using Mapster;
using MediAppoint.Doctor.Application.Commands.CreateDoctor;
using MediAppoint.Doctor.Presentation.Dtos.CreateDoctor;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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
            gp.MapGet("/",GetDoctors);
            gp.MapPost("/",CreateDoctor);
            gp.MapPut("/{id:guid}",UpdateDoctor);
        }

        private async Task UpdateDoctor( )
        {
            throw new NotImplementedException();
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

        private async Task GetDoctors()
        {
            throw new NotImplementedException();
        }
    }
}
