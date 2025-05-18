using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> SpecialOfferListAsync();
        Task<UpdateSpecialOfferDto> GetSpecialOfferByIdAsync(string id);
        Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpeacialDto);
        Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpeacialDto);
        Task DeleteSpecialOfferAsync(string id);
    }
}
