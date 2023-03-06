using AutoMapper;
using Entities.Dtos.CreationDtos;
using Entities.Dtos.UpdateDtos;
using Entities.Models;
using Model.DTOs;
using Model.Models;

namespace MovieWorldUnitTests
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
            CreateMap<MovieForCreationDto, Movie>()
                 .ForMember(m => m.Id, opt => opt.Ignore())
                 .ForMember(m => m.CreatedDate, opt => opt.Ignore())
                 .ForMember(m => m.LastModifiedDate, opt => opt.Ignore())
                 .ForMember(m => m.MovieGenres, opt => opt.Ignore())
                 .ForMember(m => m.MovieCasts, opt => opt.Ignore());
            CreateMap<MovieForUpdateDto, Movie>().ForMember(m => m.CreatedDate, opt => opt.Ignore())
                 .ForMember(m => m.LastModifiedDate, opt => opt.Ignore())
                 .ForMember(m => m.MovieGenres, opt => opt.Ignore())
                 .ForMember(m => m.MovieCasts, opt => opt.Ignore());
            CreateMap<Cast, CastDto>();
            CreateMap<UserForRegistrationDto, User>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.NormalizedUserName, opt => opt.Ignore())
                .ForMember(m => m.NormalizedEmail, opt => opt.Ignore())
                .ForMember(m => m.EmailConfirmed, opt => opt.Ignore())
                .ForMember(m => m.PasswordHash, opt => opt.Ignore())
                .ForMember(m => m.SecurityStamp, opt => opt.Ignore())
                .ForMember(m => m.ConcurrencyStamp, opt => opt.Ignore())
                .ForMember(m => m.PhoneNumberConfirmed, opt => opt.Ignore())
                .ForMember(m => m.TwoFactorEnabled, opt => opt.Ignore())
                .ForMember(m => m.LockoutEnd, opt => opt.Ignore())
                .ForMember(m => m.LockoutEnabled, opt => opt.Ignore())
                .ForMember(m => m.AccessFailedCount, opt => opt.Ignore());
        }
    }
}
