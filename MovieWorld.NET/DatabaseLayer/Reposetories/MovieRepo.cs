using DatabaseLayer.Interfaces;
using DBLibrary;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using System.Transactions;

namespace DatabaseLayer.Reposetories
{
    public class MovieRepo : IMovieRepo
    {
        private readonly MovieWorldDbContext _context;
        public MovieRepo(MovieWorldDbContext context) 
        {
            _context = context;
        }
        public Movie GetMovie(int id)
        {
            var movie = _context.Movie
                .AsNoTracking()
                .AsEnumerable()
                .Where(x => x.Id == id)
                .FirstOrDefault();
            return movie;
        }
        public List<Movie> GetMovies()
        {
            return _context.Movie
                .AsNoTracking()
                .AsEnumerable()
                .OrderBy(x => x.Name)
                .ToList();
        }
        public Movie InsertMovie(Movie movie)
        {
            _context.Movie.Add(movie);
            _context.SaveChanges();
            var newItem = _context.Movie.ToList()
                .FirstOrDefault(x => x.Name.ToLower()
                .Equals(movie.Name?.ToLower()));
            if (newItem == null) throw new Exception("Could not create the movie as expected");
            return newItem;
        }
        public void InsertMovies(List<Movie> movies)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required,new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted}))
            {
                try
                {
                    foreach (var movie in movies)
                    {
                        var success = InsertMovie(movie).Id > 0;
                        if (!success) throw new Exception($"Error inserting the movie {movie.Name}");
                    }
                    scope.Complete();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public int UpdateMovie(Movie movie)
        {
            var dbMovie = _context.Movie
                .FirstOrDefault(x => x.Id == movie.Id);
            if (dbMovie == null) throw new Exception("Movie not found");
            
            dbMovie.Name = movie.Name;
            dbMovie.Description = movie.Description;
            dbMovie.Duration = movie.Duration;
            dbMovie.PublishYear = movie.PublishYear;
            dbMovie.IMDB_Rate = movie.IMDB_Rate;

            _context.SaveChanges();
            return movie.Id;
        }
        public void UpdateMovies(List<Movie> movies)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                try
                {
                    foreach (var movie in movies)
                    {
                        var success = UpdateMovie(movie) > 0;
                        if (!success) throw new Exception($"Error updating the movie {movie.Name}");
                    }
                    scope.Complete();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public void DeleteMovie(int id)
        {
            var movie = _context.Movie.FirstOrDefault(x => x.Id == id);
            if (movie == null) return;
            _context.Movie.Remove(movie);
            _context.SaveChanges();
        }
        public void DeleteMovies(List<int> movieIds)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                try
                {
                    foreach (var movieId in movieIds)
                    {
                        DeleteMovie(movieId);
                    }
                    scope.Complete();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}