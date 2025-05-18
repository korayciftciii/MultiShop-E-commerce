using MultiShop.DtoLayer.CatalogDtos.GeneralOfferDtos;

namespace MultiShop.WebUI.Services.CatalogServices.GeneralOfferServices
{
    public class GeneralOfferService : IGeneralOfferService
    {
        private readonly HttpClient _httpClient;

        public GeneralOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateGeneralOfferAsync(CreateGeneralOfferDto createGeneralOfferDto)
        {
            await _httpClient.PostAsJsonAsync<CreateGeneralOfferDto>("GeneralOffer", createGeneralOfferDto);
        }

        public async Task DeleteGeneralOfferAsync(string id)
        {
            await _httpClient.DeleteAsync($"GeneralOffer/{id}");
        }

        public async Task<List<ResultGeneralOfferDto>> GeneralOfferListAsync()
        {
            var responseMessage = await _httpClient.GetAsync("GeneralOffer");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultGeneralOfferDto>>();
                return values is not null ? values : throw new NullReferenceException();
            }
            else
                throw new HttpRequestException("An error occured while getting general offers");
        }

        public async Task<UpdateGeneralOfferDto> GetGeneralOfferByIdAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"GeneralOffer/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadFromJsonAsync<UpdateGeneralOfferDto>();
                return values is not null ? values : throw new NullReferenceException();
            }
            else
                throw new HttpRequestException($"An error occured while getting general offers. StatusCode: {responseMessage.StatusCode}");
        }

        public async Task UpdateGeneralOfferAsync(UpdateGeneralOfferDto updateGeneralOfferDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateGeneralOfferDto>("GeneralOffer", updateGeneralOfferDto);
        }
    }
}
