using MultiShop.DtoLayer.CatalogDtos.AboutUsFooterDtos;

namespace MultiShop.WebUI.Services.CatalogServices.AboutUsFooterServices
{
    public interface IAboutUsFooterService
    {
        Task<List<ResultAboutUsFooterDto>> GetAboutUsFooterAsync();
        Task CreateAboutUsFooterAsync(CreateAboutUsFooterDto createAboutUsFooterDto);
        Task UpdateAboutUsFooterAsync(UpdateAboutUsFooterDto updateAboutUsFooterDto);
        Task DeleteAboutUsFooterAsync(string id);
        Task<UpdateAboutUsFooterDto> GetAboutUsFooterByIdAsync(string id);
    }
}
