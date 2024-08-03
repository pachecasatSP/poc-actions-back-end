using bff_app_client.Server.Domain;
using bff_app_client.Server.IoC;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.InjectServices();

var app = builder.Build();

app.UseCors((options) => {
    options.AllowAnyOrigin();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/weatherforecast/{count}", (IWeatherForecastService service, int count) =>
{
    return service.Forecast(count);
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();


