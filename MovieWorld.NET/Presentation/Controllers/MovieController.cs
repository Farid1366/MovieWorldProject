using BuisnessLayer.Interfaces;
using BuisnessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private static IMovieService _movieService;
        [HttpGet]
        public IActionResult GetMovies()
        {
            try
            {
                using (var db = DBBuilder.GetDbContext())
                {
                    _movieService = new MovieService(dbContext: db, mapper: DBBuilder.GetMapper());
                    var movies = _movieService.GetMovies();
                    return Ok(movies);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
