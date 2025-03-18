using System.Security.Claims;

namespace MultiShop.Basket.LoginService
{
    public class LoginManager : ILoginService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public LoginManager(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetUserId
        {
            get
            {
              
                if (_contextAccessor == null || _contextAccessor.HttpContext.User == null)
                {
                    throw new InvalidOperationException("HttpContext or User is null");
                }

                var userIdClaim = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim == null)
                {
                    throw new InvalidOperationException("User does not have a 'sub' claim");
                }

                return userIdClaim.Value;
            }
        }
    }
}
