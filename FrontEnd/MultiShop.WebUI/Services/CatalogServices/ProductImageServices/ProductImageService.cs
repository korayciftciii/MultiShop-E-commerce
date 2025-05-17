using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly HttpClient _httpClient;

        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductImagesAsync(CreateProductImageDto createProductImageDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductImageDto>("ProductImage", createProductImageDto);
        }

        public async Task DeleteProductImagesAsync(string id)
        {
            await _httpClient.DeleteAsync($"ProductImage/{id}");
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImagesAsync()
        {
            var responseMessage = await _httpClient.GetAsync("ProductImage");
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"An error occured while getting product's Images. StatusCode: {responseMessage.StatusCode}");
            }
            var values=await responseMessage.Content.ReadFromJsonAsync<List<ResultProductImageDto>>();
            return values != null ? values : throw new NullReferenceException();
        }

        public async Task<GetProductImagesById> GetByIdProductImagesAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"ProductImage/{id}");
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"An error occured while getting product's Images. StatusCode: {responseMessage.StatusCode}");
            }
            var value = await responseMessage.Content.ReadFromJsonAsync<GetProductImagesById>();
            return value != null ? value : throw new NullReferenceException();
        }

        public async Task<UpdateProductImageDto> GetProductImagesForUpdate(string id)
        {

            var responseMessage = await _httpClient.GetAsync($"ProductImage/{id}");
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"An error occured while getting product's Images. StatusCode: {responseMessage.StatusCode}");
            }
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateProductImageDto>();
            return value != null ? value : throw new NullReferenceException();
        }

        public async Task UpdateProductImagesAsync(UpdateProductImageDto updateProductImagesDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductImageDto>("ProductImage", updateProductImagesDto);
        }
    }
}
