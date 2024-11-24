using System.Reflection;
using System.Text;
using System.Text.Json;

namespace GymV1.BLL
{
    public class DataAccess
    {
        private static readonly HttpClientHandler _httpClientHandler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, certificate, chain, sslPolicyErrors) => true
        };

        private static readonly HttpClient _httpClient = new HttpClient(_httpClientHandler);

        public async Task<string> getRequest(string url)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
            
                string body = await response.Content.ReadAsStringAsync();
                return body;
            
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Request failed: {ex.Message}");
                return string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return string.Empty;
            }
        }

        public async Task<string> postRequest<T>(string url, T model)
        {
            try
            {
                string json = JsonSerializer.Serialize(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                string body = await response.Content.ReadAsStringAsync();
                return body;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Request failed: {ex.Message}");
                return string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return string.Empty;
            }
        }

        public async Task<string> putRequest<T>(string url, T model)
        {
        try
        {
            string json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync(url, content);
            response.EnsureSuccessStatusCode();

            string body = await response.Content.ReadAsStringAsync();
            return body;

        }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Request failed: {ex.Message}");
                return string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return string.Empty;
            }
        }

        public async Task<string> deleteRequest<T>(string url, T model)
        {
            try
            {
                string json = JsonSerializer.Serialize(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Delete, url)
                {
                    Content = content
                };

                HttpResponseMessage response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                string body = await response.Content.ReadAsStringAsync();
                return body;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Request failed: {ex.Message}");
                return string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return string.Empty;
            }
        }
    }
}

