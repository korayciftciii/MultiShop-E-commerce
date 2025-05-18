using MultiShop.DtoLayer.CatalogDtos.ServiceCardDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ServiceCardServices
{
    public class ServiceCardService : IServiceCardService
    {
        private readonly HttpClient _httpClient;

        public ServiceCardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateServiceCard(CreateServiceCardDto createServiceCardDto)
        {
            await _httpClient.PostAsJsonAsync<CreateServiceCardDto>("ServiceCard", createServiceCardDto);
        }

        public async Task DeleteServiceCard(string id)
        {
            await _httpClient.DeleteAsync($"ServiceCard/{id}");
        }

        public async Task<UpdateServiceCardDto> GetByIdServiceCardDto(string id)
        {
            var responseMessage = await _httpClient.GetAsync("ServiceCard/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadFromJsonAsync<UpdateServiceCardDto>();
                return values is not null ? values : throw new NullReferenceException();
            }
            else
                throw new HttpRequestException($"An error occured while getting service cards. StatusCode: {responseMessage.StatusCode}");
        }

        public async Task<List<ResultSerivceCardDto>> ServiceCardList()
        {
            var responseMessage = await _httpClient.GetAsync("ServiceCard");
            if (responseMessage.IsSuccessStatusCode) { 
            var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSerivceCardDto>>(jsonData);
                return values is not null ? values : new List<ResultSerivceCardDto>();
            }
            else
                throw new HttpRequestException($"An error occured while getting service cards. StatusCode: {responseMessage.StatusCode}");
        }

        public async Task UpdateServiceCard(UpdateServiceCardDto updateServiceCardDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateServiceCardDto>("ServiceCard",updateServiceCardDto);
        }
    }
}
