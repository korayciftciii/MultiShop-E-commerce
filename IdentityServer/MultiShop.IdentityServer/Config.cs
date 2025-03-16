﻿using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace MultiShop.IdentityServer;

public static class Config
{
    public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
        new ApiResource("resourceCatalog"){Scopes={"CatalogFullPermission","CatalogReadPermission"}},
        new ApiResource("resourceDiscount"){Scopes={"DiscountFullPermission"}},
        new ApiResource("resourceOrder"){Scopes={"OrderFullPermission"}},
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
        new ApiScope("DiscountFullPermission","Full Authority for Discount operations"),
        new ApiScope("OrderFullPermission","Full Authority for Order operations"),
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
            AllowedScopes={ "CatalogFullPermission" }
        },
        //manager
        new Client
        {
            ClientId="MultiShopManagerId",
            ClientName="Multi Shop Manager User",
            AllowedGrantTypes=GrantTypes.ClientCredentials,
            ClientSecrets={new Secret("multishopsecret".Sha256())},
            AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission" }
        },
        new Client
        {
            ClientId="MultiShopAdminId",
              ClientName="Multi Shop Admin User",
            AllowedGrantTypes=GrantTypes.ClientCredentials,
            ClientSecrets={new Secret("multishopsecret".Sha256())},
            AllowedScopes={ "CatalogFullPermission", "CatalogReadPermission", "DiscountFullPermission", "OrderFullPermission" ,
            IdentityServerConstants.LocalApi.ScopeName,
            IdentityServerConstants.StandardScopes.Email,
            IdentityServerConstants.StandardScopes.OpenId,
            IdentityServerConstants.StandardScopes.Profile,
            },
            AccessTokenLifetime=2000
        }
    };
}