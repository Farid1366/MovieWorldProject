using AutoMapper;
using BuisnessLayer.Interfaces;
using BuisnessLayer.Services;
using DatabaseLayer.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Model.Models;
using Moq;

namespace MovieWorldUnitTests
{
    [TestClass]
    public class MovieWorldUnitTests
    {
        private IMovieService _movieService;
        private Mock<IMovieRepo> _movieRepo;
        private static MapperConfiguration _mapperConfig;
        private static IMapper _mapper;
        private static IServiceProvider _serviceProvider;
        private const string MOIVE_NAME_1 = "Movie Test 1";
        private const string MOIVE_PUBLISH_YEAR_1 = "2023";
        private const string MOIVE_DESCRIPTION_1 = "Description1";
        private const decimal MOIVE_IMDB_RATE_1 = 10;
        private const int MOIVE_DURATION_1 = 61;
        private const string MOIVE_NAME_2 = "Movie Test 2";
        private const string MOIVE_PUBLISH_YEAR_2 = "2024";
        private const string MOIVE_DESCRIPTION_2 = "Description2";
        private const decimal MOIVE_IMDB_RATE_2 = 10;
        private const int MOIVE_DURATION_2 = 62;
        public TestContext TestContext { get; set; }
        [ClassInitialize]
        public static void InitializeTestEnvironment(TestContext testContext)
        { 
            var services = new ServiceCollection();
            services.AddAutoMapper(typeof(MappingProfile));
            _serviceProvider = services.BuildServiceProvider();
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapperConfig.AssertConfigurationIsValid();
            _mapper = _mapperConfig.CreateMapper();
        }
        [TestInitialize]
        public void InitializeTests()
        {
            InstattiateMoviesRepoMock();
            _movieService = new MovieService(_movieRepo.Object,_mapper);
        }
        private void InstattiateMoviesRepoMock()
        {
            _movieRepo = new Mock<IMovieRepo>();
            var movies = new List<Movie>()
            {
                new Movie()
                {
                    Id = 1,
                    Name = MOIVE_NAME_1,
                    PublishYear = MOIVE_PUBLISH_YEAR_1,
                    Description= MOIVE_DESCRIPTION_1,
                    IMDB_Rate = MOIVE_IMDB_RATE_1,
                    Duration = MOIVE_DURATION_1
                },
                new Movie()
                {
                    Id = 2,
                     Name = MOIVE_NAME_2,
                    PublishYear = MOIVE_PUBLISH_YEAR_2,
                    Description= MOIVE_DESCRIPTION_2,
                    IMDB_Rate = MOIVE_IMDB_RATE_2,
                    Duration = MOIVE_DURATION_2
                }
            };
            _movieRepo.Setup(m => m.GetMovies()).Returns(movies);
        }
        [TestMethod]
        public void TestGetMovies()
        {
            var result = _movieService.GetMovies();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
    }
}