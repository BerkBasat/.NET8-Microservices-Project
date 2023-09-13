using AutoMapper;
using Ecommerce.Services.ProductAPI.Data;
using Ecommerce.Services.ProductAPI.DTO;
using Ecommerce.Services.ProductAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Services.ProductAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        private readonly ResponseDTO _response;

        public ProductAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDTO();
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public ResponseDTO GetAll()
        {
            try
            {
                IEnumerable<Product> coupons = _db.Products.ToList();
                _response.Result = _mapper.Map<IEnumerable<ProductDTO>>(coupons);
            }
            catch (Exception ex) 
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDTO Get(int id)
        {
            try
            {
                Product coupon = _db.Products.First(x => x.ProductId == id);
                _response.Result = _mapper.Map<ProductDTO>(coupon);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }


        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public ResponseDTO Create([FromBody] ProductDTO couponDTO)
        {
            try
            {

                Product coupon = _mapper.Map<Product>(couponDTO);
                _db.Products.Add(coupon);
                _db.SaveChanges();
                _response.Result = _mapper.Map<ProductDTO>(coupon);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public ResponseDTO Put([FromBody] ProductDTO couponDTO)
        {
            try
            {

                Product coupon = _mapper.Map<Product>(couponDTO);
                _db.Products.Update(coupon);
                _db.SaveChanges();
                _response.Result = _mapper.Map<ProductDTO>(coupon);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDTO Delete(int id)
        {
            try
            {

                Product coupon = _db.Products.First(x => x.ProductId == id);
                _db.Products.Remove(coupon);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }
    }
}
