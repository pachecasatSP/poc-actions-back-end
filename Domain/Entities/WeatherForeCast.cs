namespace bff_app_client.Server.Domain.Entities
{
    public record WeatherForecast(int Id, DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        public string FormatDate => Date.ToString("dd/MM/yyyy");
    }
}