using MultiShop.DtoLayer.IdentityDtos.LoginDtos;

namespace MultiShop.WebUI.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> Signin(SigninDto signinDto);
        Task<bool> GetRefreshToken();
    }
}
