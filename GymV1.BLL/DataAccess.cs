using System.Reflection;
using System.Text;
using System.Text.Json;

namespace GymV1.BLL
{
    public class DataAccess
    {
        public async Task<string> getRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string body = await response.Content.ReadAsStringAsync();
                    return body;

                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine(e);
                    return "ERROR";
                }
            }
        }

        public async Task<string> postRequest<T>(string url, T model)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string json = JsonSerializer.Serialize(model);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);
                    response.EnsureSuccessStatusCode();

                    string body = await response.Content.ReadAsStringAsync();
                    return body;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine(e);
                    return "ERROR";
                }
            }
        }

        public async Task<string> putRequest<T>(string url, T model)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string json = JsonSerializer.Serialize(model);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync(url, content);
                    response.EnsureSuccessStatusCode();

                    string body = await response.Content.ReadAsStringAsync();
                    return body;

                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine(e);
                    return "ERROR";
                }
            }
        }

        public async Task<string> deleteRequest<T>(string url, T model)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string json = JsonSerializer.Serialize(model);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var request = new HttpRequestMessage(HttpMethod.Delete, url)
                    {
                        Content = content
                    };

                    HttpResponseMessage response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();

                    string body = await response.Content.ReadAsStringAsync();
                    return body;

                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine(e);
                    return "ERROR";
                }
            }
        }
    }
}
