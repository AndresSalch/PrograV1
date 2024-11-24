using GymV1.Share.Model;
using System.Text.Json;

namespace GymV1.BLL.BL
{
    public class blRutinaEjercicio
    {
        DataAccess _data = new DataAccess();
        string url = "https://192.168.100.69:7271/api";


        public async Task<List<cRutinaEjercicio>?> getModel()
        {
            try
            {
                var response = await _data.getRequest($"{url}/RutinaEjercicio/getRutinaEjercicio");
                if (string.IsNullOrWhiteSpace(response))
                {
                    Console.WriteLine("Empty response.");
                    return null;
                }

                return JsonSerializer.Deserialize<List<cRutinaEjercicio>>(response);

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

        public async Task<cRutinaEjercicio?> getModelId(int id)
        {
            try
            {
                var response = await _data.getRequest($"{url}/RutinaEjercicio/getRutinaEjercicio/{id}");

                if (string.IsNullOrWhiteSpace(response))
                {
                    Console.WriteLine("Empty response.");
                    return null;
                }

                return JsonSerializer.Deserialize<cRutinaEjercicio>(response);

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

        public async Task<string> postModel(cRutinaEjercicio model)
        {
            try
            {
                var response = await _data.postRequest<cRutinaEjercicio>($"{url}/RutinaEjercicio/agregarRutinaEjercicio", model);
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

        public async Task<string> deleteModel(cRutinaEjercicio model)
        {
            try
            {
                var response = await _data.deleteRequest<cRutinaEjercicio>($"{url}/RutinaEjercicio/borrarRutinaEjercicio", model);
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
