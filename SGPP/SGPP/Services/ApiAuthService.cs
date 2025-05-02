using System.Net.Http.Headers;

namespace SGPP.Services
{
    public class ApiAuthService
    {
        private readonly HttpClient _http;
        private string _jwtToken;

        public ApiAuthService(HttpClient http)
        {
            _http = http;
        }

        public async Task InitializeAsync()
        {
            var response = await _http.PostAsJsonAsync("/login", new { Username="admin", Password="Abc123$%" });

            if(response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<AuthResponse>();
                _jwtToken = result.Token;

                _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _jwtToken);
            }
            else
            {
                throw new Exception("Authorization login failed");
            }
        }

        public string GetJWTToken() { return _jwtToken; }

    }

    public class AuthResponse
    {
        public string Token { get; set; }
    }

}
