using MultiShop.Catalog.Dtos.ServiceCardDtos;

namespace MultiShop.Catalog.Services.ServiceCardServices
{
    public interface IServiceCardService
    {
        Task<List<ResultServiceCardDto>> ServiceCardList();
        Task<GetByIdServiceCardDto> GetByIdServiceCardDto(string id);
        Task CreateServiceCard(CreateServiceCardDto createServiceCardDto);
        Task UpdateServiceCard(UpdateServiceCardDto updateServiceCardDto);
        Task DeleteServiceCard(string id);
    }
}
