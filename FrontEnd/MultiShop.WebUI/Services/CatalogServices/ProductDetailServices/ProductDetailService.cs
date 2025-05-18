using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _httpClient;

        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteProductDetailsAsync(string id)
        {
            await _httpClient.DeleteAsync($"ProductDetail/{id}");
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync()
        {
            var responseMessage = await _httpClient.GetAsync("ProductDetail");
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"An error occured while getting product's detail. StatusCode: {responseMessage.StatusCode}");
            }
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDetailDto>>();
            return values != null ? values : new List<ResultProductDetailDto>();
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"ProductDetail/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetByIdProductDetailDto>(jsonData);
                return value != null ? value : throw new NullReferenceException();
            }
            else
                throw new HttpRequestException($"An error occured while getting product's detail. StatusCode: {responseMessage.StatusCode}");
           
        }

        public async Task<UpdateProductDetailsDto> GetProductDetailsForUpdate(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"ProductDetail/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateProductDetailsDto>(jsonData);
                return value != null ? value : throw new NullReferenceException();
            }
            else
                throw new HttpRequestException($"An error occured while getting product's detail. StatusCode: {responseMessage.StatusCode}");

        }

        public async Task UpdateProductDetailsAsync(UpdateProductDetailsDto updateProductDetailDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductDetailsDto>("ProductDetail", updateProductDetailDto);
        }
    }
}
