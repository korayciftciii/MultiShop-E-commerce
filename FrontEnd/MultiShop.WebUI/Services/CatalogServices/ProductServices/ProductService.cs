using MultiShop.DtoLayer.CatalogDtos.ProductDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDto>("product", createProductDto);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _httpClient.DeleteAsync($"product/{id}");
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            var responseMessage = await _httpClient.GetAsync("product");
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"An error occured while getting product. StatusCode: {responseMessage.StatusCode}");
            }
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDto>>();
            return values != null ? values : throw new NullReferenceException();
        }

        public async Task<GetProductIBydDto> GetByIdProductAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"product/{id}");
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"An error occured while getting product. StatusCode: {responseMessage.StatusCode}");
            }
            var value = await responseMessage.Content.ReadFromJsonAsync<GetProductIBydDto>();
            return value != null ? value : throw new NullReferenceException();
        }

        public async Task<UpdateProductDto> GetOneProductForUpdate(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"product/{id}");
            if(!responseMessage.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"An error occured while getting product. StatusCode: {responseMessage.StatusCode}");
            }
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateProductDto>();
            return value != null ? value : throw new NullReferenceException();
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Product");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"An error occured while getting product. StatusCode: {responseMessage.StatusCode}");
            }

            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductWithCategoryDto>>();

            return values ?? throw new NullReferenceException("Product not found.");
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryIdAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"product/productlistwithcategoryId?id={id}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"An error occured while getting product with category. StatusCode: {responseMessage.StatusCode}");
            }

            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductWithCategoryDto>>();
            return values ?? throw new NullReferenceException("API'den dönen ürün listesi null.");
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductDto>("product", updateProductDto);
        }
    }
}
