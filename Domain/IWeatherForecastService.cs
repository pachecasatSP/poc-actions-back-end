using bff_app_client.Server.Domain.Entities;

namespace bff_app_client.Server.Domain
{
    public interface IWeatherForecastService
    {
        WeatherForecast[] Forecast(int count);
    }
}