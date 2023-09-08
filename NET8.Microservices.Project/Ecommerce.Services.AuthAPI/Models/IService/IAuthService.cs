using Ecommerce.Services.AuthAPI.DTO;

namespace Ecommerce.Services.AuthAPI.Models.IService
{
    public interface IAuthService
    {
        Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDTO);
        Task<UserDTO> Login(LoginRequestDTO loginRequestDTO);
    }
}
