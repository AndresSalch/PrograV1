using Dapper;
using GymV1.Share.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GymV1.Share.Service
{
    public class dsRutina
    {
        private readonly string _connectionString;

        public dsRutina(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<int> addService(cRutinaDTO rutina)
        {
            using (var conn = CreateConnection())
            {
                var res = await conn.ExecuteAsync("insert into Rutina (nombre, identificacion, estado) values (@nombre, @identificacion, @estado)", rutina);
                return res;
            }

        }

        public async Task<int> deleteService(cRutina rutina)
        {
            using (var conn = CreateConnection())
            {
                var res = await conn.ExecuteAsync("delete from Rutina Where idrutina = @idrutina", rutina);
                return res;
            }
        }

        public async Task<cRutina> getServiceById(int Id)
        {
            using (var conn = CreateConnection())
            {
                var res = await conn.QueryFirstOrDefaultAsync<cRutina>("select * from Rutina Where idrutina = @id", new { id = Id });
                return res;
            }
        }

        public async Task<List<cRutina>> getServicelist()
        {
            using (var conn = CreateConnection())
            {
                var res = await conn.QueryAsync<cRutina>("Select * from Rutina");
                return res.ToList();
            }
        }

        public async Task<int> updateService(cRutina rutina)
        {
            using (var conn = CreateConnection())
            {
                var res = await conn.ExecuteAsync("update Rutina Set nombre = @nombre, identificacion = @identificacion, estado = @estado Where idrutina = @idrutina", rutina);
                return res;
            }
        }
    }
}
