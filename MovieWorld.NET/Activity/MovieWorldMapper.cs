using AutoMapper;
using Model.DTOs;
using Model.Models;

namespace Helper
{
    public class MovieWorldMapper : Profile
    {
        public MovieWorldMapper() 
        {
            CreateMaps();
        }
        private void CreateMaps()
        {
            CreateMap<Movie, MovieDto>();
            CreateMap<Cast, CastDto>();
        }
    }
}
