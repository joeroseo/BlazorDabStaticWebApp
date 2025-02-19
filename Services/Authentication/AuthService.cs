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

        /// <summary>
        /// Registers a new user with a hashed password in the Azure SQL database via Data API Builder.
        /// </summary>
        public async Task<bool> RegisterAsync(string email, string password)
        {
            var user = new User
            {
                Email = email,
                PasswordHash = HashPassword(password)
            };

            Console.WriteLine($"DEBUG: Sending JSON for Registration - {JsonSerializer.Serialize(user)}"); // Debug output

            var response = await _http.PostAsJsonAsync("rest/Users", user);

            if (!response.IsSuccessStatusCode)
            {
                string errorResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"ERROR: Registration failed - {errorResponse}");
            }

            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Logs in the user by checking the hashed password in the Azure SQL database.
        /// </summary>
        public async Task<bool> LoginAsync(string email, string password)
        {
            try
            {
                // Call the Data API Builder to get the user details
                var response = await _http.GetAsync($"rest/Users?$filter=Email eq '{email}'");

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"ERROR: Login API returned {response.StatusCode}");
                    return false;
                }

                string jsonResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"DEBUG: Received JSON Response for Login - {jsonResponse}");

                // Deserialize the response correctly
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

        /// <summary>
        /// Logs out the user and redirects to the login page.
        /// </summary>
        public async Task LogoutAsync()
        {
            _navigation.NavigateTo("/login");
        }

        /// <summary>
        /// Hashes a password using SHA-256 for secure storage.
        /// </summary>
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        /// <summary>
        /// Represents a user model that matches the Users table in the database.
        /// </summary>
        public class User
        {
            [JsonPropertyName("Email")]
            public string Email { get; set; }

            [JsonPropertyName("PasswordHash")]
            public string PasswordHash { get; set; }
        }

        /// <summary>
        /// Wrapper class to match Data API Builder response format.
        /// </summary>
        public class DataApiResponse<T>
        {
            [JsonPropertyName("value")]
            public List<T> Value { get; set; }
        }
    }
}
