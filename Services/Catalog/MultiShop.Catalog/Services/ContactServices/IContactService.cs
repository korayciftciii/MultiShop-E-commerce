using MultiShop.Catalog.Dtos.Contact;

namespace MultiShop.Catalog.Services.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> ContactListAsync();
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task UpdateContactAsync(UpdateContactDto updateContactDto);
        Task<GetContactByIdDto> GetContactByIdAsync(string id);
        Task DeleteContactAsync(string contactId);
    }
}
