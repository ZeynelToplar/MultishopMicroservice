using MultiShop.BasketService.Dtos;

namespace MultiShop.BasketService.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasketAsync(string userId);
        Task SaveBasket(BasketTotalDto basketTotalDto);
        Task DeleteBasketAsync(string userId);
    }
}
