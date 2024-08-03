using bff_app_client.Server.Domain;
using bff_app_client.Server.Domain.Entities;

namespace bff_app_client.Server.services
{
    public class WeatherforecastService : IWeatherForecastService
    {

        public WeatherForecast[] Forecast()
        {
            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };


            var forecast = Enumerable.Range(1, 20).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)).ToString("dd/MM/yyyy"),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
            .ToArray();
            return forecast;
        }
    }
}