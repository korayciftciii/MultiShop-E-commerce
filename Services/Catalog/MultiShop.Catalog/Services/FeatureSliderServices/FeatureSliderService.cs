using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly IMongoCollection<FeatureSlider> _FeatureSliderCollection;
        private readonly IMapper _mapper;
        public FeatureSliderService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _FeatureSliderCollection = database.GetCollection<FeatureSlider>(databaseSettings.FeatureSliderCollectionName);
            _mapper = mapper;
        }
        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
           var value=_mapper.Map<FeatureSlider>(createFeatureSliderDto);
            await _FeatureSliderCollection.InsertOneAsync(value);

        }

        public async Task DeleteFeatureSliderAsync(string featureSliderId)
        {

            await _FeatureSliderCollection.DeleteOneAsync(x => x.SliderId.Equals(featureSliderId));
        }

        public async Task FeatureSliderChangeStatusToFalse(string featureSliderId)
        {
            var value = await _FeatureSliderCollection.Find(x => x.SliderId.Equals(featureSliderId)).FirstOrDefaultAsync();
            value.Status = false;
            await _FeatureSliderCollection.FindOneAndReplaceAsync(x => x.SliderId.Equals(featureSliderId), value);


        }
        public async Task FeatureSliderChangeStatusToTrue(string featureSliderId)
        {
            var value = await _FeatureSliderCollection.Find(x => x.SliderId.Equals(featureSliderId)).FirstOrDefaultAsync();
            value.Status = true;
            await _FeatureSliderCollection.FindOneAndReplaceAsync(x => x.SliderId.Equals(featureSliderId), value);
        }
        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var value = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);
          
            await _FeatureSliderCollection.FindOneAndReplaceAsync(x => x.SliderId.Equals(updateFeatureSliderDto.SliderId), value);
        }

     

        public async Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            var value=await _FeatureSliderCollection.Find(x=>x.SliderId.Equals(id)).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdFeatureSliderDto>(value);
        } 

        public async Task<List<ResultFeatureSliderDto>> GetSlidersAsync()
        {
            var value = await _FeatureSliderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureSliderDto>>(value);
        }

      
    }
}
