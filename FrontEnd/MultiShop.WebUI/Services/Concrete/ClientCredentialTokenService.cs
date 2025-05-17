using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Settings;
using Duende.AccessTokenManagement;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Duende.IdentityModel.Client;

namespace MultiShop.WebUI.Services.Concrete
{
    public class ClientCredentialTokenService : IClientCredentialTokenService
    {
        private readonly HttpClient _httpClient;
        private readonly ServiceApiSettings _serviceApiSettings;
        private readonly ClientSettings _clientSettings;
        private readonly IMemoryCache _memoryCache;
        private const string TokenCacheKey = "multishoptoken";
        public ClientCredentialTokenService(IMemoryCache memoryCache, IOptions<ClientSettings> clientSettings,IOptions<ServiceApiSettings> serviceApiSettings, HttpClient httpClient)
        {
            _memoryCache = memoryCache;
            _clientSettings = clientSettings.Value;
            _serviceApiSettings = serviceApiSettings.Value;
            _httpClient = httpClient;
        }

        public async Task<string> GetTokenAsync()
        {
            if (_memoryCache.TryGetValue(TokenCacheKey, out string accessToken))
            {
                return accessToken;
            }

            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityServerUrl,
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false
                }
            });

            var clientCredentialTokenRequest = new ClientCredentialsTokenRequest
            {
                ClientId = _clientSettings.MultiShopVisitorClient.ClientId,
                ClientSecret = _clientSettings.MultiShopVisitorClient.ClientSecret,
                Address = discoveryEndPoint.TokenEndpoint
            };

            var tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);

            if (tokenResponse.IsError)
            {
                throw new Exception("Token alınırken hata oluştu: " + tokenResponse.Error);
            }

            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(tokenResponse.ExpiresIn - 60) // 60 saniye öncesinden süresi dolsun
            };

            _memoryCache.Set(TokenCacheKey, tokenResponse.AccessToken, cacheEntryOptions);

            return tokenResponse.AccessToken;
        }
    }
}

