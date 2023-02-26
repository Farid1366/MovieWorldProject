using BuisnessLayer.Interfaces;
using LoggerService;

namespace WebApi.Extensions
{
    public static class ServiceExtensions
    {
        /* CORS configuration to accept requests from different domain than our application */
        public static void ConfigureCors(this IServiceCollection services) => 
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

        /* IIS integration to host application on IIS */
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {

            });

        /* Logger Serivce initialization */
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager,LoggerManager>();
    }
}
