using AutoMapper;
using BuisnessLayer.Interfaces;
using DatabaseLayer.Interfaces;
using DatabaseLayer.Reposetories;
using DBLibrary;
using Model.DTOs;

namespace BuisnessLayer.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepo _dbRepo;
        private readonly IMapper _mapper;
        public CastService(MovieWorldDbContext dbContext, IMapper mapper)
        {
            _dbRepo = new CastRepo(context: dbContext);
            _mapper = mapper;
        }
        public List<CastDto> GetCasts(int movieId)
        {
            var casts = _dbRepo.GetCasts(movieId);
            return _mapper.Map<List<CastDto>>(casts);
        }
    }
}
