using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using MultiShop.DtoLayer.CatalogDtos.ServiceCardDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public class ContactService : IContactServices
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultContactDto>> ContactListAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                return values is not null ? values : new List<ResultContactDto>();
            }
            else
                throw new HttpRequestException($"An error occured while getting contact. StatusCode: {responseMessage.StatusCode}");
        }
        

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            await _httpClient.PostAsJsonAsync<CreateContactDto>("Contact", createContactDto);
        }

        public async Task DeleteContactAsync(string contactId)
        {
            await _httpClient.DeleteAsync($"Contact/{contactId}");
        }

        public async Task<UpdateContactDto> GetContactByIdAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadFromJsonAsync<UpdateContactDto>();
                return values is not null ? values : throw new NullReferenceException();
            }
            else
                throw new HttpRequestException($"An error occured while getting contact. StatusCode: {responseMessage.StatusCode}");
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateContactDto>("Contact", updateContactDto);
        }
    }
}
