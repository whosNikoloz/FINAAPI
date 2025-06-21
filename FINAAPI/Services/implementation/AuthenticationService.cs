using FINAAPI.Models;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Configuration;
using FINAAPI.Services.intefaces;

namespace FINAAPI.Services.implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly TokenStorageService _tokenStorage;

        public AuthenticationService(HttpClient httpClient, IConfiguration configuration, TokenStorageService tokenStorage)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["FinaApi:BaseUrl"];
            _tokenStorage = tokenStorage;
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(string login, string password)
        {
            var request = new AuthenticationRequest
            {
                Login = login,
                Password = password
            };

            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_baseUrl}/api/authentication/authenticate", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var authResponse = JsonSerializer.Deserialize<AuthenticationResponse>(responseContent, options);
            
            if (authResponse?.Token != null)
            {
                _tokenStorage.SetToken(authResponse.Token);
            }

            return authResponse ?? new AuthenticationResponse
            {
                Token = null,
                Ex = "Deserialization failed or response was null."
            };
        }
    }
} 