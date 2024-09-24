using Multishop.DiscountApi.Dtos;

namespace Multishop.DiscountApi.Services
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountCouponDto>> GetDiscountCouponListAsync();
        Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto);
        Task UpdateDiscountCouponAsync(UpdatetDiscountCouponDto updateCouponDto);
        Task DeleteDiscountCouponAsync(int id);
        Task<GetDiscountCouponByIdDto> GetDiscountCouponByIdAsync(int id);
    }
}
