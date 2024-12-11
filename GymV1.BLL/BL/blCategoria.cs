using GymV1.Share.Model;
using System.Text.Json;

namespace GymV1.BLL.BL
{
    public class blCategoria{

        DataAccess _data = new DataAccess();
        string url = "https://192.168.100.70:5092/api";

        public async Task<List<cCategoria>?> getModel()
        {
            try
            {
                var response = await _data.getRequest($"{url}/categoria/getCategorias");

                if (string.IsNullOrWhiteSpace(response))
                {
                    Console.WriteLine("Empty response.");
                    return null;
                }

                return JsonSerializer.Deserialize<List<cCategoria>>(response);

            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JSON error: {ex.Message}");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return null;
        }

        public async Task<cCategoria?> getModelId(int id)
        {
            try
            {
                var response = await _data.getRequest($"{url}/categoria/getCategoria/{id}");

                if (string.IsNullOrWhiteSpace(response))
                {
                    Console.WriteLine("Empty response.");
                    return null;
                }

                return JsonSerializer.Deserialize<cCategoria>(response); 

            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JSON error: {ex.Message}");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return null;
        }

        public async Task<string> postModel(cCategoriaDTO model)
        {
            try
            {
                var response = await _data.postRequest<cCategoriaDTO>($"{url}/categoria/agregarCategoria", model);
                return response;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return string.Empty;
        }

        public async Task<string> putModel(cCategoria model)
        {
            try
            {
                var response = await _data.putRequest<cCategoria>($"{url}/categoria/actualizarCategoria", model);
                return response;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return string.Empty;
        }

        public async Task<string> deleteModel(cCategoria model)
        {
            try
            {
                var response = await _data.deleteRequest<cCategoria>($"{url}/categoria/borrarCategoria", model);
                return response;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return string.Empty;
        }
    }
}
