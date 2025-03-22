using MultiShop.Catalog.Dtos.SpecialOffer;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpeacialDto>> SpecialOfferListAsync();
        Task<GetByIdSpecialOfferDto> GetSpecialOfferByIdAsync(string id);
        Task CreateSpecialOfferAsync(CreateSpeacialDto createSpeacialDto);
        Task UpdateSpecialOfferAsync(UpdateSpeacialDto updateSpeacialDto);
        Task DeleteSpecialOfferAsync(string id);
    }
}
