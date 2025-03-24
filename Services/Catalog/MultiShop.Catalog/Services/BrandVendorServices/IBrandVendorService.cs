using MultiShop.Catalog.Dtos.BrandVendor;

namespace MultiShop.Catalog.Services.BrandVendorServices
{
    public interface IBrandVendorService
    {
        Task<List<ResultBrandVendorDto>> BrandVendorListAsync();
        Task<GetByIdBrandVendorDto> GetByIdVendorAsync(string id);
        Task CreateBrandVendorAsync(CreateBrandVendorDto createBrandVendorDto);
        Task UpdateBrandVendorAsync(UpdateBrandVendorDto updateBrandVendorDto);
        Task DeleteBrandVendorAsync(string id);

    }
}
