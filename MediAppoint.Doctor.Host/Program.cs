using Carter;
using MediAppoint.Doctor.Application;
using MediAppoint.Doctor.Infrastructure;
using MediAppoint.Doctor.Presentation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCarter();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDoctorApplicationServices();
builder.Services.AddDoctorInfrastructureServices(builder.Configuration);
builder.Services.AddDoctorPresentationServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();
app.MapCarter();

app.UseHttpsRedirection();

 
 
app.Run();

 