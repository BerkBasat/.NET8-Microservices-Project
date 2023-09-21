using Ecommerce.Services.EmailAPI.DTO;

namespace Ecommerce.Services.EmailAPI.Services
{
    public interface IEmailService
    {
        Task EmailCartAndLog(CartDTO cartDTO);
        Task RegisterUserEmailAndLog(string email);
    }
}
