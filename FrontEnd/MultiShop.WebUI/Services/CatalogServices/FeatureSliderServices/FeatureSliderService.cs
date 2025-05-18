using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly HttpClient _httpClient;
        public FeatureSliderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _httpClient.PostAsJsonAsync<CreateFeatureSliderDto>("FeatureSlider", createFeatureSliderDto);
        }
        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _httpClient.DeleteAsync("FeatureSlider?id=" + id);
        }
        public async Task<UpdateFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("FeatureSlider/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadFromJsonAsync<UpdateFeatureSliderDto>();
                return values is not null ? values : throw new NullReferenceException();
            }
            else
                throw new HttpRequestException($"An error occured while getting sliders. StatusCode: {responseMessage.StatusCode}");

        }
        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            var responseMessage = await _httpClient.GetAsync("FeatureSlider");
            if (responseMessage.IsSuccessStatusCode) {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
                return values is not null ? values : throw new NullReferenceException();
            }
            else
                throw new HttpRequestException($"An error occured while getting sliders. StatusCode: {responseMessage.StatusCode}");

        }
        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateFeatureSliderDto>("FeatureSlider", updateFeatureSliderDto);
        }

        //public Task FeatureSliderChageStatusToTrue(string id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task FeatureSliderChageStatusToFalse(string id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
