using GymV1.Share.Model;
using System.Text.Json;

namespace GymV1.BLL.BL
{
    public class blCategoria{

        DataAccess _data = new DataAccess();

        public async Task<cCategoria?> getModel()
        {
            try
            {
                var response = await _data.getRequest("https://localhost:7271/api/Categoria/getCategorias");
                return JsonSerializer.Deserialize<cCategoria>(response);

            }catch(Exception e)
            {
                Console.Write(e);
                return new cCategoria();
            }
        }

        public async Task<cCategoria?> getModelId(int id)
        {
            try
            {
                var response = await _data.getRequest($"https://localhost:7271/api/Categoria/getCategoria/{id}");
                return JsonSerializer.Deserialize<cCategoria>(response);

            }
            catch (Exception e)
            {
                Console.Write(e);
                return new cCategoria();
            }
        }

        public async Task<string> postModel(cCategoria model)
        {
            cCategoriaDTO dto = new cCategoriaDTO() { Categoria = model.Categoria };

            try
            {
                var response = await _data.postRequest<cCategoriaDTO>("https://localhost:7271/api/Categoria/agregarCategoria", dto);
                return response;

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public async Task<string> putModel(cCategoria model)
        {
            try
            {
                var response = await _data.putRequest<cCategoria>("https://localhost:7271/api/Categoria/actualizarCategoria", model);
                return response;

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public async Task<string> deleteModel(cCategoria model)
        {
            try
            {
                var response = await _data.deleteRequest<cCategoria>("https://localhost:7271/api/Categoria/borrarCategoria", model);
                return response;

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
