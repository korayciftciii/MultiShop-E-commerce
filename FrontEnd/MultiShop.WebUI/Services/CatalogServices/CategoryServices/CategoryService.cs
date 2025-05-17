using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
             await _httpClient.PostAsJsonAsync<CreateCategoryDto>("category", createCategoryDto);

        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _httpClient.DeleteAsync($"category/{id}");
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
        {
            var responseMessage = await _httpClient.GetAsync("category");
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"An error occured while getting category. StatusCode: {responseMessage.StatusCode}");
            }
            var values=await responseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
            return values!=null ? values : throw new NullReferenceException();
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"category/{id}");
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"An error occured while getting category. StatusCode: {responseMessage.StatusCode}");
            }
            var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return value!=null ? value : throw new NullReferenceException();
        }

        public async Task<UpdateCategoryDto> GetOneCategoryForUpdate(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"category/{id}");
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"An error occured while getting category. StatusCode: {responseMessage.StatusCode}");
            }
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateCategoryDto>();
            return value != null ? value : throw new NullReferenceException();
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCategoryDto>("category",updateCategoryDto);
        }
    }
}
