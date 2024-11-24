using Dapper;
using GymV1.Share.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GymV1.Share.Service
{
    public class dsCliente 
    {
        private readonly string _connectionString;

        public dsCliente(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<int> addService(cCliente cliente)
        {
            using (var conn = CreateConnection())
            {
                var res = await conn.ExecuteAsync("insert into Cliente (nombre,identificacion,fechanacimiento,Estatura,imc,peso,Correo) values (@nombre,@identificacion,@fechanacimiento,@Estatura,@imc,@peso,@Correo)", cliente);
                return res;
            }

        }

        public async Task<int> deleteService(cCliente cliente)
        {
            using (var conn = CreateConnection())
            {
                var res = await conn.ExecuteAsync("delete from Cliente Where identificacion = @id", new { id = cliente.identificacion });
                return res;
            }
        }

        public async Task<cCliente> getServiceById(String Id)
        {
            using (var conn = CreateConnection())
            {
                var res = await conn.QueryFirstOrDefaultAsync<cCliente>("select * from Cliente Where identificacion = @id", new { id = Id });
                return res;
            }
        }

        public async Task<List<cCliente>> getServicelist()
        {
            using (var conn = CreateConnection())
            {
                var res = await conn.QueryAsync<cCliente>("Select * from Cliente");
                return res.ToList();
            }
        }

        public async Task<int> updateService(cCliente cliente)
        {
            using (var conn = CreateConnection())
            {
                var res = await conn.ExecuteAsync("update Cliente Set nombre = @nombre,fechanacimiento = @fechanacimiento,Estatura = @Estatura,imc = @imc,peso = @peso,Correo = @Correo Where identificacion = @identificacion", cliente);
                return res;
            }
        }
    }
}
