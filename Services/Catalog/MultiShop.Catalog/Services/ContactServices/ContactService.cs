using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.Contact;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly IMongoCollection<Contact> _ContactCollection;
        private readonly IMapper _Mapper;
        public ContactService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _ContactCollection = database.GetCollection<Contact>(databaseSettings.ContactCollectionName);
            _Mapper = mapper;
        }

        public async Task<List<ResultContactDto>> ContactListAsync()
        {
            var value = await _ContactCollection.Find(x => true).ToListAsync();
            return _Mapper.Map<List<ResultContactDto>>(value);
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            var value = _Mapper.Map<Contact>(createContactDto);
            await _ContactCollection.InsertOneAsync(value);
        }

        public async Task DeleteContactAsync(string contactId)
        {
            await _ContactCollection.DeleteOneAsync(x => x.ContactId.Equals(contactId));
        }

        public async Task<GetContactByIdDto> GetContactByIdAsync(string id)
        {
            var value = await _ContactCollection.Find(x => x.ContactId.Equals(id)).FirstOrDefaultAsync();
            return _Mapper.Map<GetContactByIdDto>(value);
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            var value = _Mapper.Map<Contact>(updateContactDto);
            await _ContactCollection.FindOneAndReplaceAsync(x => x.ContactId.Equals(updateContactDto.ContactId), value);
        }
    }
}
