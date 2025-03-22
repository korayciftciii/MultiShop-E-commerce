using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.SpecialOffer;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly IMongoCollection<SpecialOffer> _SpecialOfferCollection;
        private readonly IMapper _mapper;
        public SpecialOfferService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _SpecialOfferCollection = database.GetCollection<SpecialOffer>(databaseSettings.SpecialOfferCollectionName);
            _mapper = mapper;
        }
        public async Task CreateSpecialOfferAsync(CreateSpeacialDto createSpeacialDto)
        {
            var value = _mapper.Map<SpecialOffer>(createSpeacialDto);

            await  _SpecialOfferCollection.InsertOneAsync(value);   
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
          await _SpecialOfferCollection.DeleteOneAsync(x => x.SpecialOfferId.Equals(id));
        }

        public async Task<GetByIdSpecialOfferDto> GetSpecialOfferByIdAsync(string id)
        {
            var value =await _SpecialOfferCollection.Find<SpecialOffer>(x => x.SpecialOfferId.Equals(id)).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdSpecialOfferDto>(value);
        }

        public async Task<List<ResultSpeacialDto>> SpecialOfferListAsync()
        {
            var values = await _SpecialOfferCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSpeacialDto>>(values);
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpeacialDto updateSpeacialDto)
        {
            var value = _mapper.Map<SpecialOffer>(updateSpeacialDto);
            await _SpecialOfferCollection.FindOneAndReplaceAsync(x => x.SpecialOfferId.Equals(updateSpeacialDto.SpecialOfferId), value);
        }
    }
}
