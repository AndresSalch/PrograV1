using GymV1.Share.Model;
using System.Text.Json;

namespace GymV1.BLL.BL
{
    public class blCliente
    {
        DataAccess _data = new DataAccess();
        string url = "https://gymhost-hjh3d8caerf0cuc9.centralus-01.azurewebsites.net/api";


        public async Task<List<cCliente>?> getModel()
        {
            try
            {
                var response = await _data.getRequest($"{url}/Cliente/getClientes");
                if (string.IsNullOrWhiteSpace(response))
                {
                    Console.WriteLine("Empty response.");
                    return null;
                }

                return JsonSerializer.Deserialize<List<cCliente>>(response);

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

        public async Task<cCliente?> getModelId(string id)
        {
            try
            {
                var response = await _data.getRequest($"{url}/Cliente/getCliente/{id}");
            if (string.IsNullOrWhiteSpace(response))
            {
                Console.WriteLine("Empty response.");
                return null;
            }

            return JsonSerializer.Deserialize<cCliente>(response);

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

    public async Task<string> postModel(cCliente model)
        {
            try
            {
                var response = await _data.postRequest<cCliente>($"{url}/Cliente/agregarClientes", model);
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

        public async Task<string> putModel(cCliente model)
        {
            try
            {
                var response = await _data.putRequest<cCliente>($"{url}/Cliente/actualizarClientes", model);
                return response;

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public async Task<string> deleteModel(cCliente model)
        {
            try
            {
                var response = await _data.deleteRequest<cCliente>($"{url}/Cliente/borrarClientes", model);
                return response;

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
