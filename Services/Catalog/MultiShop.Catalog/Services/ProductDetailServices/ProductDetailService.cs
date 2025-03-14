using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProdutDetailService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductDetail> productDetailCollection;
        public ProductDetailService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            productDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }
        public async Task CreateProductDetailsAsync(CreateProductDetailDto createProductDetailDto)
        {
            var value = _mapper.Map<ProductDetail>(createProductDetailDto);
            await productDetailCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductDetailsAsync(string id)
        {
            await productDetailCollection.DeleteOneAsync(x => x.ProductDetailId.Equals(id));

        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync()
        {
            var values = await productDetailCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(values);   
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var value = await productDetailCollection.Find<ProductDetail>(x => x.ProductDetailId.Equals(id)).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(value);
        }

        public async Task UpdateProductDetailsAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var value=_mapper.Map<ProductDetail>(updateProductDetailDto);
            await productDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailId.Equals(updateProductDetailDto.ProductDetailId), value);

        }
    }
}
