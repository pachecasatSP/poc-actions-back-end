using bff_app_client.Server.Domain;
using bff_app_client.Server.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace bff_app_client.Server.services
{
    public class WeatherforecastService(IMemoryCache memoryCache) : IWeatherForecastService
    {
        private readonly string[] summaries = {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private IMemoryCache _memoryCache = memoryCache;
        public const string CACHE_KEY_LASTUSEDDATE = "LASTUSEDDATE";
        public const string CACHE_KEY_SENTFORECASTS = "SENTFORECASTS";
        public WeatherForecast[] Forecast(int count)
        {
            DateTime initialDate = DateTime.Now;
            if (count == 1)
            {
                initialDate = _memoryCache.Get<DateTime>(CACHE_KEY_LASTUSEDDATE);
            }
            else
            {
                var sentForecasts = _memoryCache.Get<IEnumerable<WeatherForecast>>($"{CACHE_KEY_SENTFORECASTS}_{count}");

                if (sentForecasts != null)
                {
                    return sentForecasts.ToArray();
                }
            }

            int idGenerator = 0;
            var forecast = Enumerable.Range(1, count).Select(index =>
            new WeatherForecast
            (
                ++idGenerator,
                DateOnly.FromDateTime(initialDate.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
            .ToArray();

            var lastUsedDate = forecast.Last().Date.ToDateTime(TimeOnly.MinValue);
            _memoryCache.Set(CACHE_KEY_LASTUSEDDATE, lastUsedDate);

            _memoryCache.Set<IEnumerable<WeatherForecast>>($"{CACHE_KEY_SENTFORECASTS}_{count}", forecast);
            return forecast;
        }
    }
}