using MultiShop.DtoLayer.CatalogDtos.AboutUsFooterDtos;
using MultiShop.DtoLayer.CatalogDtos.ServiceCardDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.AboutUsFooterServices
{
    public class AboutUsFooterService : IAboutUsFooterService
    {
        private readonly HttpClient _httpClient;

        public AboutUsFooterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAboutUsFooterAsync(CreateAboutUsFooterDto createAboutUsFooterDto)
        {
            await _httpClient.PostAsJsonAsync<CreateAboutUsFooterDto>("AboutUsFooter", createAboutUsFooterDto); 

        }

        public async Task DeleteAboutUsFooterAsync(string id)
        {
            await _httpClient.DeleteAsync($"AboutUsFooter/{id}");
        }

        public async Task<List<ResultAboutUsFooterDto>> GetAboutUsFooterAsync()
        {
            var responseMessage = await _httpClient.GetAsync("AboutUsFooter");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutUsFooterDto>>(jsonData);
                return values is not null ? values : throw new NullReferenceException();
            }
            else
                throw new HttpRequestException($"An error occured while getting About content. StatusCode: {responseMessage.StatusCode}");
        }

        public async Task<UpdateAboutUsFooterDto> GetAboutUsFooterByIdAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"AboutUsFooter/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadFromJsonAsync<UpdateAboutUsFooterDto>();
                return values is not null ? values : throw new NullReferenceException();
            }
            else
                throw new HttpRequestException($"An error occured while getting About content. StatusCode: {responseMessage.StatusCode}");
        }

        public async Task UpdateAboutUsFooterAsync(UpdateAboutUsFooterDto updateAboutUsFooterDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateAboutUsFooterDto>("AboutUsFooter", updateAboutUsFooterDto);
        }
    }
}
