using GymV1.Share.Model;
using System.Text.Json;

namespace GymV1.BLL.BL
{
    public class blEjercicio
    {
        DataAccess _data = new DataAccess();
        string url = "https://192.168.100.70:5092/api";


        public async Task<List<cEjercicio>?> getModel()
        {
            try
            {
                var response = await _data.getRequest($"{url}/Ejercicio/getEjercicios");

                if (string.IsNullOrWhiteSpace(response))
                {
                    Console.WriteLine("Empty response.");
                    return null;
                }

                return JsonSerializer.Deserialize<List<cEjercicio>>(response);

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

        public async Task<cEjercicio?> getModelId(int id)
        {
            try
            {
                var response = await _data.getRequest($"{url}/Ejercicio/getEjercicio/{id}");

                if (string.IsNullOrWhiteSpace(response))
                {
                    Console.WriteLine("Empty response.");
                    return null;
                }

                return JsonSerializer.Deserialize<cEjercicio>(response);

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

        public async Task<string> postModel(cEjercicioDTO model)
        {
            try
            {
                var response = await _data.postRequest<cEjercicioDTO>($"{url}/Ejercicio/agregarEjercicio", model);
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

        public async Task<string> putModel(cEjercicio model)
        {
            try
            {
                var response = await _data.putRequest<cEjercicio>($"{url}/Ejercicio/actualizaEjercicio", model);
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

        public async Task<string> deleteModel(cEjercicio model)
        {
            try
            {
                var response = await _data.deleteRequest<cEjercicio>($"{url}/Ejercicio/borrarEjercicio", model);
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
