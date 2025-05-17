using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImagesAsync();
        Task CreateProductImagesAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImagesAsync(UpdateProductImageDto updateProductImagesDto);
        Task DeleteProductImagesAsync(string id);
        Task<GetProductImagesById> GetByIdProductImagesAsync(string id);
        Task<UpdateProductImageDto> GetProductImagesForUpdate(string id);
    }
}
