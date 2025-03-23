using MultiShop.Catalog.Dtos.GeneralOfferDtos;
using MultiShop.Catalog.Dtos.SpecialOffer;

namespace MultiShop.Catalog.Services.GeneralOfferServices
{
    public interface IGeneralOfferService
    {
        Task<List<ResultGeneralOfferDto>> GeneralOfferListAsync();
        Task<GetByIdGeneralOfferDto> GetGeneralOfferByIdAsync(string id);
        Task CreateGeneralOfferAsync(CreateGeneralOfferDto createGeneralOfferDto);
        Task UpdateGeneralOfferAsync(UpdateGeneralOfferDto updateGeneralOfferDto);
        Task DeleteGeneralOfferAsync(string id);
    }
}
