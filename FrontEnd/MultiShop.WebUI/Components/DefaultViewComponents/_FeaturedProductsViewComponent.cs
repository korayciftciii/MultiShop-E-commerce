using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CatalogDtos.ServiceCardDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Components.DefaultViewComponents
{
    public class _FeaturedProductsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _FeaturedProductsViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Product");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);

                // Ürünleri Creation Date'e göre azalan sırada sırala ve son 8 ürünü al
                var latestProducts = values
                    .OrderByDescending(p => p.CreationDate)
                    .Take(8)
                    .ToList();

                return View(latestProducts);
            }
            return View();
        }
    }
}
