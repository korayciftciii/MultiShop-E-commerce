using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using MultiShop.WebUI.Services.CatalogServices.ContactServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IContactServices _contactServices;

        public ContactController(IHttpClientFactory httpClientFactory, IContactServices contactServices)
        {
            _httpClientFactory = httpClientFactory;
            _contactServices = contactServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            createContactDto.IsRead = false;
            createContactDto.createdAt = DateTime.Now;
            await _contactServices.CreateContactAsync(createContactDto);
            return RedirectToAction("Index");
         
        }
    }
}
