using BuisnessLayer.Interfaces;
using Entities.Models;
using Entities.Models.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace WebApi.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app, ILoggerManager logger) 
        { 
            app.UseExceptionHandler(appError => 
            { 
                appError.Run(async context => 
                { 
                    context.Response.ContentType = "application/json"; 
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>(); 
                    if (contextFeature != null) 
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError
                        };
                        logger.LogError($"Something went wrong: {contextFeature.Error}"); 
                        await context.Response.WriteAsync(new ErrorDetail() 
                        { 
                            StatusCode = context.Response.StatusCode, 
                            Message = contextFeature.Error.Message, 
                        }.ToString()); 
                    } 
                }); 
            }); 
        }
    }
}
