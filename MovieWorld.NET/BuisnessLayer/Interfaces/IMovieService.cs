using Entities.Dtos.CreationDtos;
using Model.DTOs;

namespace BuisnessLayer.Interfaces
{
    public interface IMovieService
    {
        MovieDto GetMovie(int id);
        List<MovieDto> GetMovies();
        MovieDto InsertMovie(MovieForCreationDto movie);
        void InsertMovies(List<MovieForCreationDto> movies);
        int UpdateMovie(MovieDto movie);
        void UpdateMovies(List<MovieDto> movies);
        void DeleteMovie(int id);
        void DeleteMovies(List<int> movieIds);
    }
}
