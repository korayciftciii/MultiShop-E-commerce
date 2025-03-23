using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.GeneralOfferDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Components.DefaultViewComponents
{
    public class _GeneralOfferViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _GeneralOfferViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/GeneralOffer");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultGeneralOfferDto>>(jsonData);
                var activeSpecialOffers = values.Where(x => x.IsActive).ToList();
                return View(activeSpecialOffers);
            }

            return View();
        }
    }
}
