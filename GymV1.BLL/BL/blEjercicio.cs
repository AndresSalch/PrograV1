using GymV1.Share.Model;
using System.Text.Json;

namespace GymV1.BLL.BL
{
    public class blEjercicio
    {
        DataAccess _data = new DataAccess();

        public async Task<cEjercicio?> getModel()
        {
            try
            {
                var response = await _data.getRequest("https://localhost:7271/api/Ejercicio/getEjercicios");
                return JsonSerializer.Deserialize<cEjercicio>(response);

            }
            catch (Exception e)
            {
                Console.Write(e);
                return new cEjercicio();
            }
        }

        public async Task<cEjercicio?> getModelId(int id)
        {
            try
            {
                var response = await _data.getRequest($"https://localhost:7271/api/Ejercicio/getEjercicio/{id}");
                return JsonSerializer.Deserialize<cEjercicio>(response);

            }
            catch (Exception e)
            {
                Console.Write(e);
                return new cEjercicio();
            }
        }

        public async Task<string> postModel(cEjercicio model)
        {
            cEjercicioDTO dto = new cEjercicioDTO() { Descripcion = model.Descripcion, IdCategoria = model.IdCategoria };

            try
            {
                var response = await _data.postRequest<cEjercicioDTO>("https://localhost:7271/api/Ejercicio/agregarEjercicio", dto);
                return response;

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public async Task<string> putModel(cEjercicio model)
        {
            try
            {
                var response = await _data.putRequest<cEjercicio>("https://localhost:7271/api/Ejercicio/actualizaEjercicio", model);
                return response;

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public async Task<string> deleteModel(cEjercicio model)
        {
            try
            {
                var response = await _data.deleteRequest<cEjercicio>("https://localhost:7271/api/Ejercicio/borrarEjercicio", model);
                return response;

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
