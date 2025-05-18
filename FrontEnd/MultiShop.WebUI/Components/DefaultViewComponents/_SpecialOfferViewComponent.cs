using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Components.DefaultViewComponents
{
    public class _SpecialOfferViewComponent :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ISpecialOfferService _specialOfferService;
        public _SpecialOfferViewComponent(IHttpClientFactory httpClientFactory, ISpecialOfferService specialOfferService)
        {
            _httpClientFactory = httpClientFactory;
            _specialOfferService = specialOfferService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response=await _specialOfferService.SpecialOfferListAsync();
            return response is not null ? View(response) : View();
        }
    }
}
