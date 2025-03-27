using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.AboutUsFooterDtos;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.Components.UIViewComponents
{
    public class _FooterAboutUsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _FooterAboutUsViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/AboutUsFooter");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutUsFooterDto>>(jsonData);
                return View(values);
            }

            return View();

        }
    }
}
