using Ecommerce.Services.EmailAPI.DTO;
using Ecommerce.Services.EmailAPI.Message;

namespace Ecommerce.Services.EmailAPI.Services
{
    public interface IEmailService
    {
        Task EmailCartAndLog(CartDTO cartDTO);
        Task RegisterUserEmailAndLog(string email);
        Task LogOrderPlaced(RewardsMessage rewardsDTO);
    }
}
