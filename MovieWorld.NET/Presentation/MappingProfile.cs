using AutoMapper;
using Entities.Dtos.CreationDtos;
using Entities.Dtos.UpdateDtos;
using Entities.Models;
using Model.DTOs;
using Model.Models;

namespace Presentation
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMaps();
        }
        private void CreateMaps()
        {
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieForCreationDto, Movie>();
            CreateMap<MovieForUpdateDto, Movie>();
            CreateMap<Cast, CastDto>();
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
