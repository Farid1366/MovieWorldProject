using BuisnessLayer.Interfaces;
using Entities.Dtos.CreationDtos;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private static IMovieService _movieService;
        private static ICastService _castService;
        public MovieController(IMovieService movieService, ICastService castService)
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
        [HttpGet("{id:int}", Name = "MovieById")]
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
        [HttpPost]
        public IActionResult CreateMovie([FromBody] MovieForCreationDto movie)
        {
            if (movie is null)
                return BadRequest("MovieForCreationDto object is null");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            var createdMovie = _movieService.InsertMovie(movie);
            return CreatedAtRoute("MovieById", new { id = createdMovie.Id }, createdMovie);
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteMovie(int id)
        {
            _movieService.DeleteMovie(id);
            return NoContent();
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateMovie(int id,[FromBody] MovieForUpdateDto movie)
        {
            if (movie is null)
                return BadRequest("MovieForUpdateDto object is null");
            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            movie.Id = id;
            _movieService.UpdateMovie(movie: movie);
            return NoContent();
        }
    }
}
