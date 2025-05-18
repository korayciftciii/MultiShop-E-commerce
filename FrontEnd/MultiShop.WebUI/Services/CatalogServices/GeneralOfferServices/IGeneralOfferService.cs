using MultiShop.DtoLayer.CatalogDtos.GeneralOfferDtos;

namespace MultiShop.WebUI.Services.CatalogServices.GeneralOfferServices
{
    public interface IGeneralOfferService
    {
        Task<List<ResultGeneralOfferDto>> GeneralOfferListAsync();
        Task<UpdateGeneralOfferDto> GetGeneralOfferByIdAsync(string id);
        Task CreateGeneralOfferAsync(CreateGeneralOfferDto createGeneralOfferDto);
        Task UpdateGeneralOfferAsync(UpdateGeneralOfferDto updateGeneralOfferDto);
        Task DeleteGeneralOfferAsync(string id);
    }
}
