namespace bff_app_client.Server.Domain.Entities
{
    public record WeatherForecast(string Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}