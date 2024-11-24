using GymV1.Share.Model;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;

namespace GymV1.Share.Service
{
    public class dsRutinaEjercicio
    {
        private readonly string _connectionString;

        public dsRutinaEjercicio(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<int> addService(cRutinaEjercicio rutinaE)
        {
            using (var conn = CreateConnection())
            {
                var res = await conn.ExecuteAsync("insert into RutinaEjercicio (idrutina, idejercicio, cantidadseries, repeticiones, descripcion) values (@idrutina, @idejercicio, @cantidadseries, @repeticiones, @descripcion)", rutinaE);
                return res;
            }

        }

        public async Task<int> deleteService(cRutinaEjercicio rutinaE)
        {
            using (var conn = CreateConnection())
            {
                var res = await conn.ExecuteAsync("delete from RutinaEjercicio Where idrutina = @idrutina", rutinaE);
                return res;
            }
        }

        public async Task<cRutinaEjercicio> getServiceById(int Id)
        {
            using (var conn = CreateConnection())
            {
                var res = await conn.QueryFirstOrDefaultAsync<cRutinaEjercicio>("select * from RutinaEjercicio Where idrutina = @id", new { id = Id });
                return res;
            }
        }

        public async Task<List<cRutinaEjercicio>> getServicelist()
        {
            using (var conn = CreateConnection())
            {
                var res = await conn.QueryAsync<cRutinaEjercicio>("Select * from RutinaEjercicio");
                return res.ToList();
            }
        }
    }
}
