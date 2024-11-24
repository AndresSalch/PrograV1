using GymV1.Share.Model;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

namespace GymV1.Share.Service
{
    public class dsCategoria
    {
        private readonly string _connectionString;

        public dsCategoria(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<int> addService(cCategoriaDTO categoria)
        {
            using (var conn = CreateConnection())
            {
                var res = await conn.ExecuteAsync("Insert into Categoria (Categoria) values (@Categoria)", categoria);
                return res;
            }
        }

        public async Task<int> deleteService(cCategoria categoria)
        {
            using (var conn = CreateConnection())
            {
                var res = await conn.ExecuteAsync("delete from Categoria Where IdCategoria = @id", new { id = categoria.IdCategoria });
                return res;
            }
        }

        public async Task<cCategoria> getServiceById(int Id)
        {
            using (var conn = CreateConnection())
            {
                var res = await conn.QueryFirstOrDefaultAsync<cCategoria>("select * from Categoria Where IdCategoria = @id", new { id = Id });
                return res;
            }
        }

        public async Task<List<cCategoria>> getServicelist()
        {
            using (var conn = CreateConnection())
            {
                var res = await conn.QueryAsync<cCategoria>("Select * from Categoria");
                return res.ToList();
            }
        }

        public async Task<int> updateService(cCategoria categoria)
        {
            using (var conn = CreateConnection())
            {
                var res = await conn.ExecuteAsync("update Categoria Set Categoria = @Categoria Where IdCategoria = @IdCategoria", categoria);
                return res;
            }
        }
    }
}
