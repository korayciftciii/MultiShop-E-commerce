using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.Controllers
{
  
    public class ProductListController : Controller
    {
        
        private readonly IHttpClientFactory _clientFactory;

        public ProductListController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public IActionResult Index(string id)
        {
            ViewBag.CategoryId = id;
            return View();
        }


        
        public IActionResult ProductDetail( string productId)
        {
            ViewBag.ProductId = productId;
            return View();
        }
   

    }
}
