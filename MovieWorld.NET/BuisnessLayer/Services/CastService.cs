using AutoMapper;
using BuisnessLayer.Interfaces;
using DatabaseLayer.Interfaces;
using DatabaseLayer.Reposetories;
using DBLibrary;
using Entities.Models.Exceptions;
using Model.DTOs;

namespace BuisnessLayer.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepo _castRepo;
        private readonly IMovieRepo _movieRepo;
        private readonly IMapper _mapper;
        public CastService(MovieWorldDbContext dbContext, IMapper mapper)
        {
            _castRepo = new CastRepo(context: dbContext);
            _movieRepo = new MovieRepo(context: dbContext);
            _mapper = mapper;
        }
        public List<CastDto> GetCasts(int movieId)
        {
            var movie = _movieRepo.GetMovie(movieId);
            if (movie is null)
            {
                throw new MovieNotFoundException(movieId);
            }
            var casts = _castRepo.GetCasts(movieId);
            return _mapper.Map<List<CastDto>>(casts);
        }
    }
}
