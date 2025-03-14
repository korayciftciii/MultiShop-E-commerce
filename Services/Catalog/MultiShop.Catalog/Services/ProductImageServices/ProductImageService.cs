using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductImage> productImageCollection;
        public ProductImageService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            productImageCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }
        public async Task CreateProductImagesAsync(CreateProductImageDto createProductImageDto)
        {
         var value=_mapper.Map<ProductImage>(createProductImageDto);    
            await productImageCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImagesAsync(string id)
        {
            await productImageCollection.DeleteOneAsync(x => x.ProductImageId.Equals(id));
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImagesAsync()
        {
            var values = await productImageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImagesDtoAsync(string id)
        {
            var value = await productImageCollection.Find<ProductImage>(x => x.ProductImageId.Equals(id)).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(value);
        }

        public async Task UpdateProductImagesAsync(UpdateProductImageDto updateProductImagesDto)
        {
            var value=_mapper.Map<ProductImage>(updateProductImagesDto);
            await productImageCollection.FindOneAndReplaceAsync(x => x.ProductImageId.Equals(updateProductImagesDto.ProductImageId), value);

        }
    }
}
