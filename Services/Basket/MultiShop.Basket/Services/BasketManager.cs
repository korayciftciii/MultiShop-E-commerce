using MultiShop.Basket.Dtos;
using MultiShop.Basket.Settings;
using System.Text.Json;

namespace MultiShop.Basket.Services
{
    public class BasketManager : IBasketService
    {
        private readonly RedisService _service;

        public BasketManager(RedisService service)
        {
            _service = service;
        }

        public async Task DeleteBasket(string userId)
        {
            await _service.GetDb().KeyDeleteAsync(userId);
        }

        public async Task<BasketTotalDto> GetBasket(string userId)
        {
            var existBasket = await _service.GetDb().StringGetAsync(userId);
            return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
        }

        public async Task  SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _service.GetDb().StringSetAsync(basketTotalDto.UserId, JsonSerializer.Serialize(basketTotalDto));
        }
    }
}
