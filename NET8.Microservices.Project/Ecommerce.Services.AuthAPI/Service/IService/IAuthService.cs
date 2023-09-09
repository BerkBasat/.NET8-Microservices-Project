using Ecommerce.Services.AuthAPI.DTO;

namespace Ecommerce.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDTO registrationRequestDTO);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<bool> AssingRole(string email, string roleName);
    }
}
