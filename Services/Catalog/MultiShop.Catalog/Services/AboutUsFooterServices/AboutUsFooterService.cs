using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.AboutUsFooter;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.AboutUsFooterServices
{
    public class AboutUsFooterService : IAboutUsFooterService
    {
        private readonly IMongoCollection<AboutUsFooter> _AboutUsFooterCollection;
        private readonly IMapper _mapper;
        public AboutUsFooterService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _AboutUsFooterCollection = database.GetCollection<AboutUsFooter>(databaseSettings.AboutUsFooterCollectionName);
            _mapper = mapper;
        }
        public async Task CreateAboutUsFooterAsync(CreateAboutUsFooterDto createAboutUsFooterDto)
        {
             await _AboutUsFooterCollection.InsertOneAsync(_mapper.Map<AboutUsFooter>(createAboutUsFooterDto));
        }

        public async Task<List<ResultAboutUsFooterDto>> GetAboutUsFooterAsync()
        {
            var values=await _AboutUsFooterCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultAboutUsFooterDto>>(values);
        }

        public async Task UpdateAboutUsFooterAsync(UpdateAboutUsFooterDto updateAboutUsFooterDto)
        {
            var value = _mapper.Map<AboutUsFooter>(updateAboutUsFooterDto);
            await _AboutUsFooterCollection.FindOneAndReplaceAsync(x => x.ContentId.Equals(updateAboutUsFooterDto.ContentId), value);
        }
        public async Task<GetByIdAboutUsFooterDto> GetAboutUsFooterByIdAsync(string id)
        {
            var value = await _AboutUsFooterCollection.Find(x => x.ContentId.Equals(id)).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdAboutUsFooterDto>(value);
        }
        public async Task DeleteAboutUsFooterAsync(string id)
        {
            await _AboutUsFooterCollection.DeleteOneAsync(x => x.ContentId.Equals(id));
        }
    }
}
