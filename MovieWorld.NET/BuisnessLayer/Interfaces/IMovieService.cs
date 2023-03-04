using Entities.Dtos.CreationDtos;
using Entities.Dtos.UpdateDtos;
using Model.DTOs;

namespace BuisnessLayer.Interfaces
{
    public interface IMovieService
    {
        MovieDto GetMovie(int id);
        List<MovieDto> GetMovies();
        Task<List<MovieDto>> GetMoviesAsync(int pageNumber,int pageSize);
        MovieDto InsertMovie(MovieForCreationDto movie);
        void InsertMovies(List<MovieForCreationDto> movies);
        int UpdateMovie(MovieForUpdateDto movie);
        void UpdateMovies(List<MovieForUpdateDto> movies);
        void DeleteMovie(int id);
        void DeleteMovies(List<int> movieIds);
    }
}
