using Ecommerce.Services.RewardAPI.Message;

namespace Ecommerce.Services.RewardAPI.Services
{
    public interface IRewardService
    {
        Task UpdateRewards(RewardsMessage rewardsMessage);
    }
}
