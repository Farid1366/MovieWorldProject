using Model.DTOs;
using Model.Models;

namespace BuisnessLayer.Interfaces
{
    public interface IMovieService
    {
        MovieDto GetMovie(int id);
        List<MovieDto> GetMovies();
        int InsertMovie(MovieDto movie);
        void InsertMovies(List<MovieDto> movies);
        int UpdateMovie(MovieDto movie);
        void UpdateMovies(List<MovieDto> movies);
        void DeleteMovie(int id);
        void DeleteMovies(List<int> movieIds);
    }
}
