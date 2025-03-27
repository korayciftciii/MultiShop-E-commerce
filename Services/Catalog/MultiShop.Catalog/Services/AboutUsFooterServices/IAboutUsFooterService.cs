using MultiShop.Catalog.Dtos.AboutUsFooter;

namespace MultiShop.Catalog.Services.AboutUsFooterServices
{
    public interface IAboutUsFooterService
    {
        Task<List<ResultAboutUsFooterDto>> GetAboutUsFooterAsync();
        Task CreateAboutUsFooterAsync(CreateAboutUsFooterDto createAboutUsFooterDto);
        Task UpdateAboutUsFooterAsync(UpdateAboutUsFooterDto updateAboutUsFooterDto);
        Task DeleteAboutUsFooterAsync(string id);
        Task<GetByIdAboutUsFooterDto> GetAboutUsFooterByIdAsync(string id);
    }
}
