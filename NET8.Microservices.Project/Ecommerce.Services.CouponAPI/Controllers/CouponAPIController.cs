using Ecommerce.Services.CouponAPI.Data;
using Ecommerce.Services.CouponAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CouponAPIController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public object Get()
        {
            try
            {
                IEnumerable<Coupon> coupons = _db.Coupons.ToList();
                return coupons;
            }
            catch (Exception ex) 
            {

            }

            return null;
        }

        [HttpGet]
        [Route("{id:int}")]
        public object GetCoupon(int id)
        {
            try
            {
                Coupon coupon = _db.Coupons.First(x => x.CouponId == id);
                return coupon;
            }
            catch (Exception ex)
            {

            }

            return null;
        }
    }
}
