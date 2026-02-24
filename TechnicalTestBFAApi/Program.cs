using Application;
using Application.DTOs;
using DataAcces;
using ExternalServices;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

string? environment = builder.Configuration.GetConnectionString("connectionDb");

string urlApi = builder.Configuration.GetSection("ApiStrings:apiRegion").Value ?? throw new Exception("ApiRegion no configurada");

builder.Services.AddDataAccessConnection(environment)
                .AddResourcesApiConnection(urlApi)
                .AddDataAccessConfiguration(builder.Configuration)
                .AddApplicationConfiguration();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(x => x.Value!.Errors.Count > 0)
            .SelectMany(x => x.Value!.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();

        var message = string.Join(" | ", errors);

        var result = new ApiResponse<string>(false, message, null);
        return new BadRequestObjectResult(result);
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
