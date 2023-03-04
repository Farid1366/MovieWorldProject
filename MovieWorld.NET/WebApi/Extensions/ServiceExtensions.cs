using BuisnessLayer.Interfaces;
using DBLibrary;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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

        /* DBContext */
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<MovieWorldDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MovieWorld")));

        /**/
        public static void ConfigureVersioning(this IServiceCollection services) 
        { 
            services.AddApiVersioning(options => 
            {
                options.ReportApiVersions = true; 
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0); 
            }); 
        }

        public static void ConfigureSwagger(this IServiceCollection services) 
        { 
            services.AddSwaggerGen(s => { 
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "Movie World API", Version = "v1" }); 
            }); 
        }
    }
}
