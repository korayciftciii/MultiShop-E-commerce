using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.Components.DefaultViewComponents
{
    public class _CarouselViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _CarouselViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/FeatureSlider");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);

                // Sadece Status == true olanları filtrele
                var activeSliders = values.Where(x => x.Status).ToList();

                return View(activeSliders);
            }

            return View();

        }
    }
}
