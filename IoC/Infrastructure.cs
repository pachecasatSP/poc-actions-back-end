namespace bff_app_client.Server.IoC
{
    public static class InfrastrucureDI
    {
        public static void InjectInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<CustomMemoryCache>();
        }
    }
}