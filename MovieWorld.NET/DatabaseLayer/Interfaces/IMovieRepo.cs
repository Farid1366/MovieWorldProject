using Model.Models;

namespace DatabaseLayer.Interfaces
{
    public interface IMovieRepo
    {
        Movie GetMovie(int id);
        List<Movie> GetMovies();
        int InsertMovie(Movie movie);
        void InsertMovies(List<Movie> movies);
        int UpdateMovie(Movie movie);
        void UpdateMovies(List<Movie> movies);
        void DeleteMovie(int id);
        void DeleteMovies(List<int> movieIds);
    }
}
