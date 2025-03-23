using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ServiceCardDtos;
using MultiShop.Catalog.Dtos.SpecialOffer;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ServiceCardServices
{
    public class ServiceCardService : IServiceCardService
    {
        private readonly IMongoCollection<ServiceCard> _ServiceCardCollection;
        private readonly IMapper _mapper;
        public ServiceCardService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _ServiceCardCollection = database.GetCollection<ServiceCard>(databaseSettings.ServiceCardCollectionName);
            _mapper = mapper;
        }

        public async Task CreateServiceCard(CreateServiceCardDto createServiceCardDto)
        {
            var value = _mapper.Map<ServiceCard>(createServiceCardDto);
            await _ServiceCardCollection.InsertOneAsync(value);
        }

        public async Task DeleteServiceCard(string id)
        {
            await _ServiceCardCollection.DeleteOneAsync(x => x.FeatureId.Equals(id));
        }

        public async Task<GetByIdServiceCardDto> GetByIdServiceCardDto(string id)
        {
            var value = await _ServiceCardCollection.Find<ServiceCard>(x => x.FeatureId.Equals(id)).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdServiceCardDto>(value);
        }

        public async Task<List<ResultServiceCardDto>> ServiceCardList()
        {
           var values = await _ServiceCardCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultServiceCardDto>>(values);
        }

        public async Task UpdateServiceCard(UpdateServiceCardDto updateServiceCardDto)
        {

            var value = _mapper.Map<ServiceCard>(updateServiceCardDto);
            await _ServiceCardCollection.FindOneAndReplaceAsync(x => x.FeatureId.Equals(updateServiceCardDto.FeatureId), value);

        }
    }
}
