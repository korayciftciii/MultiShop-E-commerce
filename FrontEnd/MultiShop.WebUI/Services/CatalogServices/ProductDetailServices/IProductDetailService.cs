using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync();
        Task UpdateProductDetailsAsync(UpdateProductDetailsDto updateProductDetailDto);
        Task DeleteProductDetailsAsync(string id);
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
        Task<UpdateProductDetailsDto> GetProductDetailsForUpdate(string id);
    }
}
