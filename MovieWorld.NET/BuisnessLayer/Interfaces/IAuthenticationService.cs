using Entities.Dtos.CreationDtos;
using Microsoft.AspNetCore.Identity;

namespace BuisnessLayer.Interfaces
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth); 
        Task<string> CreateToken();
    }
}
