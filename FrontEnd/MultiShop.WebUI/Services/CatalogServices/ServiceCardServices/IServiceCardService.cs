using MultiShop.DtoLayer.CatalogDtos.ServiceCardDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ServiceCardServices
{
    public interface IServiceCardService
    {
        Task<List<ResultSerivceCardDto>> ServiceCardList();
        Task<UpdateServiceCardDto> GetByIdServiceCardDto(string id);
        Task CreateServiceCard(CreateServiceCardDto createServiceCardDto);
        Task UpdateServiceCard(UpdateServiceCardDto updateServiceCardDto);
        Task DeleteServiceCard(string id);
    }
}
