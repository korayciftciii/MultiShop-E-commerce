using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImagesAsync();
        Task CreateProductImagesAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImagesAsync(UpdateProductImageDto updateProductImagesDto);
        Task DeleteProductImagesAsync(string id);
        Task<GetByIdProductImageDto> GetByIdProductImagesAsync(string id);
    }
}
