using BuisnessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private static IMovieService _movieService;
        private static ICastService _castService;
        public MovieController(IMovieService movieService,ICastService castService)
        {
            _movieService = movieService;
            _castService = castService;
        }
        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = _movieService.GetMovies();
            return Ok(movies);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetMovie(int id)
        {
            var movie = _movieService.GetMovie(id);
            return Ok(movie);
        }
        [HttpGet("{movieId:int}/casts")]
        public IActionResult GetCastsForMovie(int movieId)
        {
            var cast = _castService.GetCasts(movieId);
            return Ok(cast);
        }
    }
}
