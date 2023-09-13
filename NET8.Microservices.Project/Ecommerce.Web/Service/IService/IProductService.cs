using Ecommerce.Web.Models;

namespace Ecommerce.Web.Service.IService
{
    public interface IProductService
    {
        Task<ResponseDTO?> GetProductAsync(string couponCode);
        Task<ResponseDTO?> GetAllProductsAsync();
        Task<ResponseDTO?> GetProductByIdAsync(int id);
        Task<ResponseDTO?> CreateProductsAsync(ProductDTO productDTO);
        Task<ResponseDTO?> UpdateProductsAsync(ProductDTO productDTO);
        Task<ResponseDTO?> DeleteProductsAsync(int id);
    }
}
