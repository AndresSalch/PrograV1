using GymV1.Share.Model;
using System.Text.Json;

namespace GymV1.BLL.BL
{
    public class blRutina
    {
        DataAccess _data = new DataAccess();

        public async Task<cRutina?> getModel()
        {
            try
            {
                var response = await _data.getRequest("https://localhost:7271/api/Rutina/getRutina");
                return JsonSerializer.Deserialize<cRutina>(response);

            }
            catch (Exception e)
            {
                Console.Write(e);
                return new cRutina();
            }
        }

        public async Task<cRutina?> getModelId(int id)
        {
            try
            {
                var response = await _data.getRequest($"https://localhost:7271/api/Rutina/getRutina/{id}");
                return JsonSerializer.Deserialize<cRutina>(response);

            }
            catch (Exception e)
            {
                Console.Write(e);
                return new cRutina();
            }
        }

        public async Task<string> postModel(cRutina model)
        {
            cRutinaDTO dto = new cRutinaDTO() { Nombre = model.Nombre, Identificacion = model.Identificacion, Estado = model.Estado };

            try
            {
                var response = await _data.postRequest<cRutinaDTO>("https://localhost:7271/api/Rutina/agregarRutina", dto);
                return response;

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public async Task<string> putModel(cRutina model)
        {
            try
            {
                var response = await _data.putRequest<cRutina>("https://localhost:7271/api/Rutina/actualizarRutina", model);
                return response;

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public async Task<string> deleteModel(cRutina model)
        {
            try
            {
                var response = await _data.deleteRequest<cRutina>("https://localhost:7271/api/Rutina/borrarRutina", model);
                return response;

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
