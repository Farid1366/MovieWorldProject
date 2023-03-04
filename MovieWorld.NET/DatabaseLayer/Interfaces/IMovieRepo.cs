using Model.Models;
using Presentation.RequestFeatures;

namespace DatabaseLayer.Interfaces
{
    public interface IMovieRepo
    {
        Movie GetMovie(int id);
        List<Movie> GetMovies();
        Task<List<Movie>> GetMoviesAsync(int pageNumber, int pageSize);
        Movie InsertMovie(Movie movie);
        void InsertMovies(List<Movie> movies);
        int UpdateMovie(Movie movie);
        void UpdateMovies(List<Movie> movies);
        void DeleteMovie(int id);
        void DeleteMovies(List<int> movieIds);
    }
}
