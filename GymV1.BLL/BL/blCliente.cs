using GymV1.Share.Model;
using System.Text.Json;

namespace GymV1.BLL.BL
{
    public class blCliente
    {
        DataAccess _data = new DataAccess();

        public async Task<cCliente?> getModel()
        {
            try
            {
                var response = await _data.getRequest("https://localhost:7271/api/Cliente/getClientes");
                return JsonSerializer.Deserialize<cCliente>(response);

            }
            catch (Exception e)
            {
                Console.Write(e);
                return new cCliente();
            }
        }

        public async Task<cCliente?> getModelId(int id)
        {
            try
            {
                var response = await _data.getRequest($"https://localhost:7271/api/Cliente/getCliente/{id}");
                return JsonSerializer.Deserialize<cCliente>(response);

            }
            catch (Exception e)
            {
                Console.Write(e);
                return new cCliente();
            }
        }

        public async Task<string> postModel(cCliente model)
        {
            try
            {
                var response = await _data.postRequest<cCliente>("https://localhost:7271/api/Cliente/agregarClientes", model);
                return response;

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public async Task<string> putModel(cCliente model)
        {
            try
            {
                var response = await _data.putRequest<cCliente>("https://localhost:7271/api/Cliente/actualizarClientes", model);
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
                var response = await _data.deleteRequest<cCliente>("https://localhost:7271/api/Cliente/borrarClientes", model);
                return response;

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
