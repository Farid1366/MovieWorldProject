using WebApi.Extensions;
using NLog;
using BuisnessLayer.Interfaces;
using BuisnessLayer.Services;
using Presentation;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<ICastService, CastService>();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(MovieWorldMapper));
builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
builder.Services.AddControllers(config => {
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
}).AddXmlDataContractSerializerFormatters()
.AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.

var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);
if(app.Environment.IsProduction())
    app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{ 
    ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.All
});
app.UseAuthorization();
app.MapControllers();

app.Run();
