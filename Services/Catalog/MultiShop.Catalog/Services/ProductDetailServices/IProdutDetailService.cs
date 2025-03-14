using MultiShop.Catalog.Dtos.ProductDetailDtos;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProdutDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync();
        Task CreateProductDetailsAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailsAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailsAsync(string id);
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
    }
}
