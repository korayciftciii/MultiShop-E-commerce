using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.BrandVendor;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.BrandVendorServices
{
    public class BrandVendorService : IBrandVendorService
    {
        private readonly IMongoCollection<BrandVendor> _branVendorCollection;
        private readonly IMapper _mapper;
        public BrandVendorService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _branVendorCollection = database.GetCollection<BrandVendor>(databaseSettings.BrandVendorCollectionName);
            _mapper = mapper;
        }
        public async Task<List<ResultBrandVendorDto>> BrandVendorListAsync()
        {
            var values=await _branVendorCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultBrandVendorDto>>(values);
        }

        public async Task CreateBrandVendorAsync(CreateBrandVendorDto createBrandVendorDto)
        {
           var value = _mapper.Map<BrandVendor>(createBrandVendorDto);
            await _branVendorCollection.InsertOneAsync(value);
        }

        public async Task DeleteBrandVendorAsync(string id)
        {
            await _branVendorCollection.DeleteOneAsync(x => x.BrandId.Equals(id));
        }

        public async Task<GetByIdBrandVendorDto> GetByIdVendorAsync(string id)
        {
            var value = await _branVendorCollection.Find<BrandVendor>(x => x.BrandId.Equals(id)).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdBrandVendorDto>(value);
        }

        public async Task UpdateBrandVendorAsync(UpdateBrandVendorDto updateBrandVendorDto)
        {
            var value = _mapper.Map<BrandVendor>(updateBrandVendorDto);
            await _branVendorCollection.FindOneAndReplaceAsync(x => x.BrandId.Equals(updateBrandVendorDto.BrandId), value);
        }
    }
}
