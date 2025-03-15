using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscocuntController : ControllerBase
    {
        private readonly IDiscountService _dicountService;
        public DiscocuntController(IDiscountService discountService)
        {
            _dicountService = discountService;
        }
        [HttpGet]
        public async Task<IActionResult> DiscountCouponList()
        {
            var values =await _dicountService.GetAllCouponAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountCouponById(int id)
        {
            var value = await _dicountService.GetByIdCouponAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateCouponDto createCouponDto)
        {
            await _dicountService.CreateCouponAsync(createCouponDto);
            return Ok("Coupon Had Deleted successfully created");

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _dicountService.DeleteCouponAsync(id);
            return Ok("Coupon Had Been Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateCouponDto updateCouponDto)
        {
            await _dicountService.UpdateCouponAsync(updateCouponDto);
            return Ok("Coupon Had been Updated");
        }
    }
}

