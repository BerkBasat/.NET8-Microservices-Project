using Ecommerce.Services.ShoppingCartAPI.DTO;

namespace Ecommerce.Services.ShoppingCartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
    }
}
