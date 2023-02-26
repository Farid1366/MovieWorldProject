using AutoMapper;
using BuisnessLayer.Interfaces;
using DatabaseLayer.Interfaces;
using DatabaseLayer.Reposetories;
using DBLibrary;
using Model.DTOs;
using Model.Models;

namespace BuisnessLayer.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepo _dbRepo;
        private readonly IMapper _mapper;
        public MovieService(MovieWorldDbContext dbCOntext,IMapper mapper) 
        {
            _dbRepo = new MovieRepo(context: dbCOntext);
            _mapper = mapper;
        }
        public MovieDto GetMovie(int id)
        {
            return _mapper.Map<MovieDto>(_dbRepo.GetMovie(id));
        }
        public List<MovieDto> GetMovies()
        {
            return _mapper.Map<List<MovieDto>>(_dbRepo.GetMovies());
        }
        public int InsertMovie(MovieDto movie)
        {
            return _dbRepo.InsertMovie(_mapper.Map<Movie>(movie));
        }
        public void InsertMovies(List<MovieDto> movies)
        {
            try
            {
                _dbRepo.InsertMovies(_mapper.Map<List<Movie>>(movies));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The transaction has failed: {ex.Message}");
            }
        }
        public int UpdateMovie(MovieDto movie)
        {
            if (movie.Id < 0) throw new ArgumentException("Please set the movie id before update");
            return _dbRepo.UpdateMovie(_mapper.Map<Movie>(movie));
        }
        public void UpdateMovies(List<MovieDto> movies)
        {
            try
            {
                _dbRepo.UpdateMovies(_mapper.Map<List<Movie>>(movies));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The transaction has failed: {ex.Message}");
            }
        }
        public void DeleteMovie(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Please set a valid item id before deleting");
            }
            _dbRepo.DeleteMovie(id);
        }
        public void DeleteMovies(List<int> movieIds)
        {
            try
            {
                _dbRepo.DeleteMovies(movieIds);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The transaction has failed: {ex.Message}");
            }
        }
    }
}
