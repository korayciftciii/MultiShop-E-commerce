using MultiShop.DtoLayer.CatalogDtos.BrandVendorDtos;
using MultiShop.DtoLayer.CatalogDtos.ServiceCardDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.BrandVendorServices
{
    public class BrandVendorService : IBrandVendorService
    {
        private readonly HttpClient _httpClient;

        public BrandVendorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultBrandVendorDto>> BrandVendorListAsync()
        {
            var responseMessage = await _httpClient.GetAsync("BrandVendor");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandVendorDto>>(jsonData);
                return values is not null ? values : throw new NullReferenceException();
            }
            else
                throw new HttpRequestException($"An error occured while getting brands. StatusCode: {responseMessage.StatusCode}");
        }

        public async Task CreateBrandVendorAsync(CreateBrandVendorDto createBrandVendorDto)
        {
            await _httpClient.PostAsJsonAsync<CreateBrandVendorDto>("BrandVendor", createBrandVendorDto);
        }

        public async Task DeleteBrandVendorAsync(string id)
        {
            await _httpClient.DeleteAsync($"BrandVendor/{id}");
        }

        public async Task<UpdateBrandVendorDto> GetByIdVendorAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"BrandVendor/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBrandVendorDto>(jsonData);
                return values is not null ? values : throw new NullReferenceException();
            }
            else
                throw new HttpRequestException($"An error occured while getting brands. StatusCode: {responseMessage.StatusCode}");
        
        }

        public async Task UpdateBrandVendorAsync(UpdateBrandVendorDto updateBrandVendorDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateBrandVendorDto>("BrandVendor", updateBrandVendorDto);
        }
    }
}
