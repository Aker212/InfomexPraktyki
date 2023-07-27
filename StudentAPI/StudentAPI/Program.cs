using Application.Mappings;
using Application.Services;
using Application.Services.Abstractions;
using Application.Validators;
using Application.Validators.Abstractions;
using Core.Repositories;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentValidator, StudentValidator>();


builder.Services.AddScoped<IAdresService, AdresService>();
builder.Services.AddScoped<IAdresRepository, AdresRepository>();

builder.Services.AddScoped<IKursService, KursService>();
builder.Services.AddScoped<IKursRepository, KursRepository>();

builder.Services.AddScoped<IWydzialService, WydzialService>();
builder.Services.AddScoped<IWydzialRepository, WydzialRepository>();




builder.Services.AddDbContext<StudentAppContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton(AutoMapperConfig.Initialize());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Student API", Version = "v1" });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
