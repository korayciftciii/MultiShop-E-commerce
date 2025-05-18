using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly HttpClient _httpClient;

        public SpecialOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpeacialDto)
        {
            await _httpClient.PostAsJsonAsync<CreateSpecialOfferDto>("specialoffer", createSpeacialDto);
                
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _httpClient.DeleteAsync($"specialoffer/{id}");
        }

        public async Task<UpdateSpecialOfferDto> GetSpecialOfferByIdAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"specialoffer/{id}");
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"An error occured while getting special offer. StatusCode: {responseMessage.StatusCode}");
            }
            else if(responseMessage.IsSuccessStatusCode)
            {
                var value = await responseMessage.Content.ReadFromJsonAsync<UpdateSpecialOfferDto>();
                return value !=null ? value : throw new NullReferenceException();
            }
            else
            {
                throw new HttpRequestException($"An error occured while getting special offer. StatusCode: {responseMessage.StatusCode}");
            }
        }

        public async Task<List<ResultSpecialOfferDto>> SpecialOfferListAsync()
        {
            var responseMessage = await _httpClient.GetAsync($"specialoffer");
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"An error occured while getting special offer. StatusCode: {responseMessage.StatusCode}");
            }
            else if (responseMessage.IsSuccessStatusCode)
            {
                var value = await responseMessage.Content.ReadFromJsonAsync<List<ResultSpecialOfferDto>>();
                return value != null ? value : throw new NullReferenceException();
            }
            else
            {
                throw new HttpRequestException($"An error occured while getting special offer. StatusCode: {responseMessage.StatusCode}");
            }
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpeacialDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateSpecialOfferDto>("specialoffer", updateSpeacialDto);
        }
    }
}
