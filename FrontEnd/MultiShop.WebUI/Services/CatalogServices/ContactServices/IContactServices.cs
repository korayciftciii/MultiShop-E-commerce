using MultiShop.DtoLayer.CatalogDtos.ContactDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public interface IContactServices
    {
        Task<List<ResultContactDto>> ContactListAsync();
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task UpdateContactAsync(UpdateContactDto updateContactDto);
        Task<UpdateContactDto> GetContactByIdAsync(string id);
        Task DeleteContactAsync(string contactId);
    }
}
