using GymV1.Share.Model;
using System.Text.Json;

namespace GymV1.BLL.BL
{
    public class blRutinaEjercicio
    {
        DataAccess _data = new DataAccess();
        string url = "https://gymhost-hjh3d8caerf0cuc9.centralus-01.azurewebsites.net/api";


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
