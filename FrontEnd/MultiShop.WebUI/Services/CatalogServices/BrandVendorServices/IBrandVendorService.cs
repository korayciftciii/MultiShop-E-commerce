using MultiShop.DtoLayer.CatalogDtos.BrandVendorDtos;

namespace MultiShop.WebUI.Services.CatalogServices.BrandVendorServices
{
    public interface IBrandVendorService
    {
        Task<List<ResultBrandVendorDto>> BrandVendorListAsync();
        Task<UpdateBrandVendorDto> GetByIdVendorAsync(string id);
        Task CreateBrandVendorAsync(CreateBrandVendorDto createBrandVendorDto);
        Task UpdateBrandVendorAsync(UpdateBrandVendorDto updateBrandVendorDto);
        Task DeleteBrandVendorAsync(string id);
    }
}
