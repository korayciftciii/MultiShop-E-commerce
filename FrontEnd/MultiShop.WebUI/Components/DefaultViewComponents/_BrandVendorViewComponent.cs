using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandVendorDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Components.DefaultViewComponents
{
    public class _BrandVendorViewComponent: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _BrandVendorViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/BrandVendor");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandVendorDto>>(jsonData);

                // Sadece Status == true olanları filtrele
                var activeVendors = values.Where(x => x.IsActive).ToList();

                return View(activeVendors);
            }

            return View();

        }
    }
}
