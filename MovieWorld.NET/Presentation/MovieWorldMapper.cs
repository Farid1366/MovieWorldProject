using AutoMapper;
using Entities.Dtos.CreationDtos;
using Model.DTOs;
using Model.Models;

namespace Presentation
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
            CreateMap<MovieForCreationDto, Movie>();
            CreateMap<MovieForUpdateDto, Movie>();
            CreateMap<Cast, CastDto>();
        }
    }
}
