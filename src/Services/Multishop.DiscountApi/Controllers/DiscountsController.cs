using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.DiscountApi.Dtos;
using Multishop.DiscountApi.Services;

namespace Multishop.DiscountApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountCouponList()
        {
            var values = await _discountService.GetDiscountCouponListAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountCouponById(int id)
        {
            var values = await _discountService.GetDiscountCouponByIdAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto createCouponDto)
        {
            await _discountService.CreateDiscountCouponAsync(createCouponDto);
            return Ok("Kupon basariyla olusturuldu");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _discountService.DeleteDiscountCouponAsync(id);
            return Ok("Kupon basariyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdatetDiscountCouponDto updatetCouponDto)
        {
            await _discountService.UpdateDiscountCouponAsync(updatetCouponDto);
            return Ok("Kupon basariyla guncellendi");
        }
    }
}
