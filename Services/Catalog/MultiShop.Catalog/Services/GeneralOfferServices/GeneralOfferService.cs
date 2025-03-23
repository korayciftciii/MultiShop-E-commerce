using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.GeneralOfferDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.GeneralOfferServices
{
    public class GeneralOfferService : IGeneralOfferService
    {
        private readonly IMongoCollection<GeneralOffer> _GeneralOfferCollection;
        private readonly IMapper _mapper;
        public GeneralOfferService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _GeneralOfferCollection = database.GetCollection<GeneralOffer>(databaseSettings.GeneralOfferCollectionName);

            _mapper = mapper;
        }

        public async Task CreateGeneralOfferAsync(CreateGeneralOfferDto createGeneralOfferDto)
        {
           var value = _mapper.Map<GeneralOffer>(createGeneralOfferDto);
            await _GeneralOfferCollection.InsertOneAsync(value);
        }

        public async Task DeleteGeneralOfferAsync(string id)
        {
            await _GeneralOfferCollection.DeleteOneAsync(x => x.OfferId.Equals(id)); 
        }

        public async Task<List<ResultGeneralOfferDto>> GeneralOfferListAsync()
        {
           var values=await _GeneralOfferCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultGeneralOfferDto>>(values);
        }

        public async Task<GetByIdGeneralOfferDto> GetGeneralOfferByIdAsync(string id)
        {
          var value =await _GeneralOfferCollection.Find<GeneralOffer>(x => x.OfferId.Equals(id)).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdGeneralOfferDto>(value);
        }

        public async Task UpdateGeneralOfferAsync(UpdateGeneralOfferDto updateGeneralOfferDto)
        {
            var value = _mapper.Map<GeneralOffer>(updateGeneralOfferDto);
           await _GeneralOfferCollection.FindOneAndReplaceAsync(x => x.OfferId.Equals(updateGeneralOfferDto.OfferId), value);
        }
    }
}
