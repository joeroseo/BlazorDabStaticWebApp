using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using BlazorSportStoreAuth.Interfaces; // ✅ Correct interface reference

namespace BlazorSportStoreAuth.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigation;

        public AuthService(HttpClient http, NavigationManager navigation)
        {
            _http = http;
            _navigation = navigation;
        }

        public async Task<bool> RegisterAsync(string email, string password)
        {
            var user = new User
            {
                Email = email,
                PasswordHash = HashPassword(password)
            };

            Console.WriteLine($"DEBUG: Sending JSON for Registration - {JsonSerializer.Serialize(user)}");

            var response = await _http.PostAsJsonAsync("data-api/rest/Users", user);

            if (!response.IsSuccessStatusCode)
            {
                string errorResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"ERROR: Registration failed - {errorResponse}");
            }

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            try
            {
                var response = await _http.GetAsync($"data-api/rest/Users?$filter=Email eq '{email}'");

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"ERROR: Login API returned {response.StatusCode}");
                    return false;
                }

                string jsonResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"DEBUG: Received JSON Response for Login - {jsonResponse}");

                var users = JsonSerializer.Deserialize<DataApiResponse<User>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (users != null && users.Value.Count > 0)
                {
                    string storedHash = users.Value[0].PasswordHash;
                    string enteredHash = HashPassword(password);

                    if (storedHash == enteredHash)
                    {
                        _navigation.NavigateTo("/");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR during login: {ex.Message}");
            }

            return false;
        }

        public async Task LogoutAsync()
        {
            _navigation.NavigateTo("/login");
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        public class User
        {
            [JsonPropertyName("Email")]
            public string Email { get; set; }

            [JsonPropertyName("PasswordHash")]
            public string PasswordHash { get; set; }
        }

        public class DataApiResponse<T>
        {
            [JsonPropertyName("value")]
            public List<T> Value { get; set; }
        }
    }
}
