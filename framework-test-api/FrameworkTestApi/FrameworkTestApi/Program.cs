using FrameworkTestApi.Application.Commands.Responses;
using MediatR;
using System.Reflection;

var CorsName = "_cors";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(Assembly.GetAssembly(typeof(CreateDecompositionResponse)));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsName,
                      builder =>
                      {
                          builder.WithOrigins("*");
                          builder.WithHeaders("*");
                      });
});

var app = builder.Build();

app.UseCors(CorsName);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
