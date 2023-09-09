using Ecommerce.Web.Models;

namespace Ecommerce.Web.Service.IService
{
    public interface IAuthService
    {
        Task<ResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO);
        Task<ResponseDTO> RegisterAsync(RegistrationRequestDTO registrationRequestDTO);
        Task<ResponseDTO> AssignRoleAsync(RegistrationRequestDTO registrationRequestDTO);

    }
}
