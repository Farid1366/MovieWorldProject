using AutoMapper;
using BuisnessLayer.Services;
using DBLibrary;
using Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Presentation
{
    public class DBBuilder
    {
        private static IConfigurationRoot _configuration;
        private static DbContextOptionsBuilder<MovieWorldDbContext> _optionsBuilder;
        private static MapperConfiguration _mapperConfig;
        private static IMapper _mapper;
        private static IServiceProvider _serviceProvider;
        private static void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
            _optionsBuilder = new DbContextOptionsBuilder<MovieWorldDbContext>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MovieWorld"));
        }
        private static void BuildMapper()
        {
            var services = new ServiceCollection();
            services.AddAutoMapper(typeof(MovieWorldMapper));
            _serviceProvider = services.BuildServiceProvider();

            _mapperConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile<MovieWorldMapper>();
            });
            _mapperConfig.AssertConfigurationIsValid();
            _mapper = _mapperConfig.CreateMapper();
        }
        public static MovieWorldDbContext GetDbContext() 
        {
            BuildOptions();
            return new MovieWorldDbContext(_optionsBuilder.Options);
        }
        public static IMapper GetMapper() 
        {
            BuildMapper();
            return _mapper;
        }
    }
}
