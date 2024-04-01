namespace Web.Services
{
    public static class ServicesCollection
    {
        internal static IServiceCollection AddManagers(this IServiceCollection services, IConfiguration config)
        {

            services.AddHttpClient("hostAPI", client =>
            {
                client.BaseAddress = new Uri(config["settings:urlBaseAPI"]);
                client.DefaultRequestHeaders.Add("xApiKey", config["settings:xApiKey"]);
                client.Timeout = TimeSpan.FromMinutes(1);

            });

            return services;

        }
    }
}
