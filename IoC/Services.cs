using bff_app_client.Server.Domain;
using bff_app_client.Server.services;

namespace bff_app_client.Server.IoC
{
    public static class ServicesDI
    {
        public static void InjectServices(this IServiceCollection services){
            services.AddScoped<IWeatherForecastService, WeatherforecastService>();
        }
    }
}