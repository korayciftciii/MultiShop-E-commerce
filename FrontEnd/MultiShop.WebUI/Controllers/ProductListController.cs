using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

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



        public IActionResult ProductDetail(string productId)
        {
            ViewBag.ProductId = productId;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReview(CreateCommentDto createCommentDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7075/api/Comments", stringContent);

            return response.IsSuccessStatusCode ? Ok() : StatusCode((int)response.StatusCode);
        }

    }
}
