namespace MultiShop.IdentityServer.Dtos
{
    public class UserLoginDto
    {
        public string userName { get; set; }
        public string password { get; set; }
        public bool isPersistence { get; set; }
    }
}
