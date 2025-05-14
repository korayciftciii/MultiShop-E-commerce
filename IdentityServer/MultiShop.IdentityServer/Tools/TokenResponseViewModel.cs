namespace MultiShop.IdentityServer.Tools
{
    public class TokenResponseViewModel
    {
        public TokenResponseViewModel(string token, DateTime expireData )
        {
            Token = token;
            ExpireData = expireData;
        }

        public string Token { get; set; }
        public DateTime ExpireData { get; set; }
    }
}
