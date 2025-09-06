using FastEndpoints;
using MediAppoint.Patient.Application;
using MediAppoint.Patient.Infrastructure;
using MediAppoint.Patient.Presentation;
using SharedKernel.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
 builder.Services.AddSwaggerGen();
builder.Services.AddPatientPresentationServices(); 
builder.Services.AddPatientApplicationServices();
builder.Services.AddPatientInfrastructureServices(builder.Configuration);
var app = builder.Build();
 
    //app.UseSwagger();
    //app.UseSwaggerUI();
 

app.UseHttpsRedirection();


app.UseFastEndpoints(c =>
{
    c.Endpoints.RoutePrefix = "api";
}).UseSwagger().UseSwaggerUI() ;
app.Run();
 