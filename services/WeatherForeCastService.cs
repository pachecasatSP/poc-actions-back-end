using bff_app_client.Server.Domain;
using bff_app_client.Server.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace bff_app_client.Server.services
{
    public class WeatherforecastService(IMemoryCache memoryCache) : IWeatherForecastService
    {
        private IMemoryCache _memoryCache = memoryCache;
        public const string CACHE_KEY = "LASTUSEDDATE";

        public WeatherForecast[] Forecast(int count)
        {
            DateOnly initialDate = DateOnly.FromDateTime(DateTime.Now);
            if (count == 1)
            {
               initialDate = _memoryCache.Get<DateOnly>(CACHE_KEY);
            }

            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            var forecast = Enumerable.Range(1, count).Select(index =>
            new WeatherForecast
            (
                initialDate.AddDays(index).ToString("dd/MM/yyyy"),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
            .ToArray();
            var lastUsedDate = forecast.Last().Date;
            _memoryCache.Set<DateOnly>(CACHE_KEY, DateOnly.Parse(lastUsedDate));


            return forecast;
        }
    }
}