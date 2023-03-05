using BuisnessLayer.Interfaces;
using Entities.Dtos.CreationDtos;
using Entities.Dtos.UpdateDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Presentation.RequestFeatures;

namespace Presentation.Controllers
{
    [ApiVersion("1.0")]
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
        [Authorize]
        public async Task<IActionResult> GetMovies([FromQuery] MovieParameters movieParamaeters)
        {
            var pagedMovies = await _movieService.GetMoviesAsync(movieParamaeters.PageNumber, movieParamaeters.PageSize);
            return Ok(pagedMovies);
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
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult CreateMovie([FromBody] MovieForCreationDto movie)
        {
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
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult UpdateMovie(int id,[FromBody] MovieForUpdateDto movie)
        {
            movie.Id = id;
            _movieService.UpdateMovie(movie: movie);
            return NoContent();
        }
    }
}
