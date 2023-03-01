using Entities.Dtos.CreationDtos;
using Model.DTOs;

namespace BuisnessLayer.Interfaces
{
    public interface IMovieService
    {
        MovieDto GetMovie(int id);
        List<MovieDto> GetMovies();
        Task<List<MovieDto>> GetMoviesAsync();
        MovieDto InsertMovie(MovieForCreationDto movie);
        void InsertMovies(List<MovieForCreationDto> movies);
        int UpdateMovie(MovieForUpdateDto movie);
        void UpdateMovies(List<MovieForUpdateDto> movies);
        void DeleteMovie(int id);
        void DeleteMovies(List<int> movieIds);
    }
}
