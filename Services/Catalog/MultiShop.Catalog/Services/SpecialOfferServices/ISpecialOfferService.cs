using MultiShop.Catalog.Dtos.SpecialOffer;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> SpecialOfferListAsync();
        Task<GetByIdSpecialOfferDto> GetSpecialOfferByIdAsync(string id);
        Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpeacialDto);
        Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpeacialDto);
        Task DeleteSpecialOfferAsync(string id);
    }
}
