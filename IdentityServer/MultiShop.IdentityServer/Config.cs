using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace MultiShop.IdentityServer;

public static class Config
{
    public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
        new ApiResource("resourceCatalog"){Scopes={"CatalogFullPermission","CatalogReadPermission"}},
        new ApiResource("resourceDiscount"){Scopes={"DiscountFullPermission","DiscountReadPermission"}},
        new ApiResource("resourceOrder"){Scopes={"OrderFullPermission","OrderReadPermission"}},
        new ApiResource("resourceCargo"){Scopes={"CargoFullPermission","CargoReadPermission"}},
        new ApiResource("resourceBasket"){Scopes={"BasketFullPermission"}},
        new ApiResource("resourceImages"){Scopes={"ImagesFullPermission"}},
        new ApiResource("resourcePayment"){Scopes={"PaymentFullPermission"}},
        new ApiResource("resourceOcelot"){Scopes={"OcelotFullPermission"}},
        new ApiResource("resourceComment"){Scopes={"CommentFullPermission"}},
        new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

    public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Email(),
        new IdentityResources.Profile()
    };
    public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
    {
        new ApiScope("CatalogFullPermission","Full Authority for catalog operations"),
        new ApiScope("CatalogReadPermission","Reading Authority for catalog"),
        new ApiScope("DiscountReadPermission","Reading Authority for discount"),
        new ApiScope("OrderReadPermission","Reading Authority for order"),
        new ApiScope("DiscountFullPermission","Full Authority for Discount operations"),
        new ApiScope("OrderFullPermission","Full Authority for Order operations"),
        new ApiScope("CargoFullPermission","Full Authority for Cargo operations"),
        new ApiScope("CargoReadPermission","Reading Authority for cargo"),
        new ApiScope("BasketFullPermission","Full Authority for Basket operation"),
        new ApiScope("PaymentFullPermission","Full Authority for Payment Operations"),
        new ApiScope("ImagesFullPermission","Full Authority for Images Operations"),
        new ApiScope("OcelotFullPermission","Full Authority for Ocelot Operations"),
        new ApiScope("CommentFullPermission","Full Authority for Comment Operations"),
        new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
    };
    public static IEnumerable<Client> Clients => new Client[]
    {
        //visitor
        new Client
        {
            ClientId="MultiShopVisitorId",
            ClientName="Multi Shop Visitor User",
            AllowedGrantTypes=GrantTypes.ClientCredentials,
            ClientSecrets={new Secret("multishopsecret".Sha256())},
            AllowedScopes={ "CatalogFullPermission", "DiscountFullPermission" , "OcelotFullPermission","CommentFullPermission" ,"ImageFullPermission", "CargoFullPermission","OrderFullPermission"}
        },
        //manager
        new Client
        {
            ClientId="MultiShopManagerId",
            ClientName="Multi Shop Manager User",
            AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
            ClientSecrets={new Secret("multishopsecret".Sha256())},
            AllowedScopes={
                "CatalogFullPermission" ,
                "BasketFullPermission" ,
                "OcelotFullPermission",
                "PaymentFullPermission" ,
                "ImageFullPermission",
             IdentityServerConstants.LocalApi.ScopeName,
            IdentityServerConstants.StandardScopes.Email,
            IdentityServerConstants.StandardScopes.OpenId,
            IdentityServerConstants.StandardScopes.Profile,}
        },
        new Client
        {
            ClientId="MultiShopAdminId",
              ClientName="Multi Shop Admin User",
            AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
            ClientSecrets={new Secret("multishopsecret".Sha256())},
            AllowedScopes={
                "CatalogFullPermission",
                "CatalogReadPermission",
                "OrderReadPermission",
                "CargoReadPermission",
                "DiscountReadPermission",
                "DiscountFullPermission",
                "OrderFullPermission" ,
                "CargoFullPermission" ,
                "BasketFullPermission",
                "PaymentFullPermission",
                "ImagesFullPermission",
                "OcelotFullPermission",
                "CommentFullPermission",
            IdentityServerConstants.LocalApi.ScopeName,
            IdentityServerConstants.StandardScopes.Email,
            IdentityServerConstants.StandardScopes.OpenId,
            IdentityServerConstants.StandardScopes.Profile,
            },
            AccessTokenLifetime=60
        }
    };
}