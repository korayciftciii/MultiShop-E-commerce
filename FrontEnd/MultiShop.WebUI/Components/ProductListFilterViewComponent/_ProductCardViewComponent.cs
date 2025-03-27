using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace MultiShop.WebUI.Components.ProductListFilterViewComponent
{
    public class _ProductCardViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductCardViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string? id)
        {
            if (id is not null)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"https://localhost:7070/api/Product/productlistwithcategoryId?id={id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var JsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(JsonData);
                    return View(values);
                }
            }
            else
            {

                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:7070/api/Product");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var JsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(JsonData);
                    return View(values);
                }

            }
            return View(new List<ResultProductDto>());
        }
    }
}
