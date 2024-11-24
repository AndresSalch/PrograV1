using GymV1.Share.Model;
using System.Text.Json;

namespace GymV1.BLL.BL
{
    public class blRutinaEjercicio
    {
        DataAccess _data = new DataAccess();

        public async Task<cRutinaEjercicio?> getModel()
        {
            try
            {
                var response = await _data.getRequest("https://localhost:7271/api/RutinaEjercicio/getRutinaEjercicio");
                return JsonSerializer.Deserialize<cRutinaEjercicio>(response);

            }
            catch (Exception e)
            {
                Console.Write(e);
                return new cRutinaEjercicio();
            }
        }

        public async Task<cRutinaEjercicio?> getModelId(int id)
        {
            try
            {
                var response = await _data.getRequest($"https://localhost:7271/api/RutinaEjercicio/getRutinaEjercicio/{id}");
                return JsonSerializer.Deserialize<cRutinaEjercicio>(response);

            }
            catch (Exception e)
            {
                Console.Write(e);
                return new cRutinaEjercicio();
            }
        }

        public async Task<string> postModel(cRutinaEjercicio model)
        {
            try
            {
                var response = await _data.postRequest<cRutinaEjercicio>("https://localhost:7271/api/RutinaEjercicio/agregarRutinaEjercicio", model);
                return response;

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public async Task<string> deleteModel(cRutinaEjercicio model)
        {
            try
            {
                var response = await _data.deleteRequest<cRutinaEjercicio>("https://localhost:7271/api/RutinaEjercicio/borrarRutinaEjercicio", model);
                return response;

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
