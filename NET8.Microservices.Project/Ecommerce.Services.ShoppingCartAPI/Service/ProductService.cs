using Ecommerce.Services.ShoppingCartAPI.DTO;
using Ecommerce.Services.ShoppingCartAPI.Service.IService;
using Newtonsoft.Json;

namespace Ecommerce.Services.ShoppingCartAPI.Service
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var client = _httpClientFactory.CreateClient("Product");
            var response = await client.GetAsync($"/api/product");
            var apiContent = await response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);

            if(res.IsSuccess)
            {
                return JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(Convert.ToString(res.Result));
            }
            return new List<ProductDTO>();
        }
    }
}
