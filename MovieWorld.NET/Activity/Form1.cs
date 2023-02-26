using AutoMapper;
using AutoMapper.QueryableExtensions;
using BuisnessLayer.Interfaces;
using BuisnessLayer.Services;
using DBLibrary;
using Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Model.DTOs;

namespace Activity
{
    public partial class Form1 : Form
    {
        private static IConfigurationRoot _configuration;
        private static DbContextOptionsBuilder<MovieWorldDbContext> _optionsBuilder;
        private static MapperConfiguration _mapperConfig;
        private static IMapper _mapper;
        private static IServiceProvider _serviceProvider;

        private static IMovieService _movieService;
        public Form1()
        {
            InitializeComponent();
            BuildOptions();
            BuildMapper();
            using (var db = new MovieWorldDbContext(_optionsBuilder.Options))
            {
                _movieService = new MovieService(dbCOntext: db, mapper: _mapper);
                ListMovies();
            }
        }
        private void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
            _optionsBuilder = new DbContextOptionsBuilder<MovieWorldDbContext>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MovieWorld"));
        }
        private void BuildMapper()
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
        private static void ListMovies()
        {
            using (var db = new MovieWorldDbContext(_optionsBuilder.Options))
            {
                var movies = _movieService.GetMovies();
                movies.ForEach(x => Console.WriteLine($"New Item: {x.Name}"));
            }
        }
    }
}