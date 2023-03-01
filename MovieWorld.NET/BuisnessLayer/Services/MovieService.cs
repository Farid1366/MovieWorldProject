using AutoMapper;
using BuisnessLayer.Interfaces;
using DatabaseLayer.Interfaces;
using DatabaseLayer.Reposetories;
using DBLibrary;
using Entities.Dtos.CreationDtos;
using Entities.Models.Exceptions;
using Model.DTOs;
using Model.Models;

namespace BuisnessLayer.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepo _dbRepo;
        private readonly IMapper _mapper;
        public MovieService(MovieWorldDbContext dbContext,IMapper mapper) 
        {
            _dbRepo = new MovieRepo(context: dbContext);
            _mapper = mapper;
        }
        public MovieDto GetMovie(int id)
        {
            var movie = _dbRepo.GetMovie(id);
            if (movie is null)
            {
                throw new MovieNotFoundException(id);
            }
            return _mapper.Map<MovieDto>(movie);
        }
        public List<MovieDto> GetMovies()
        {
            var movies = _dbRepo.GetMovies();
            return _mapper.Map<List<MovieDto>>(movies);
        }
        public async Task<List<MovieDto>> GetMoviesAsync()
        {
            var movies = await _dbRepo.GetMoviesAsync();
            return _mapper.Map<List<MovieDto>>(movies);
        }
        public MovieDto InsertMovie(MovieForCreationDto movie)
        {
            var newItem = _dbRepo.InsertMovie(_mapper.Map<Movie>(movie));
            return _mapper.Map<MovieDto>(newItem);
        }
        public void InsertMovies(List<MovieForCreationDto> movies)
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
        public int UpdateMovie(MovieForUpdateDto movie)
        {
            if (movie.Id < 0)
            {
                throw new ArgumentException("Please set the movie id before update");
            }
            return _dbRepo.UpdateMovie(_mapper.Map<Movie>(movie));
        }
        public void UpdateMovies(List<MovieForUpdateDto> movies)
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
            var movie = _dbRepo.GetMovie(id);
            if (movie is null)
            {
                throw new MovieNotFoundException(id);
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
