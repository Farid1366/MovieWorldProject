using BuisnessLayer.Interfaces;
using DBLibrary;
using Entities.Models;
using LoggerService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

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

        /**/
        public static void ConfigureSwagger(this IServiceCollection services) 
        { 
            services.AddSwaggerGen(s => { 
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "Movie World API", Version = "v1" }); 
            }); 
        }

        /**/
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric= false;
                o.Password.RequiredLength = 10;
                o.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<MovieWorldDbContext>()
            .AddDefaultTokenProviders();
        }

        /**/
        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration) 
        { 
            var jwtSettings = configuration.GetSection("JwtSettings"); 
            var secretKey = Environment.GetEnvironmentVariable("SECRET"); 
            services.AddAuthentication(opt => 
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; 
            }).AddJwtBearer(options => 
            { 
                options.TokenValidationParameters = new TokenValidationParameters 
                { 
                    ValidateIssuer = true, 
                    ValidateAudience = true, 
                    ValidateLifetime = true, 
                    ValidateIssuerSigningKey = true, 
                    ValidIssuer = jwtSettings["validIssuer"], 
                    ValidAudience = jwtSettings["validAudience"], 
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["secretKey"])) 
                }; 
            }); 
        }
    }
}
