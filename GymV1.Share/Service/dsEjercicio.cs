﻿using GymV1.Share.Model;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;

namespace GymV1.Share.Service
{
    public class dsEjercicio
    {
        private readonly string _connectionString;

        public dsEjercicio(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<int> addService(cEjercicioDTO ejercicio)
        {
            using (var conn = CreateConnection())
            {
                var res = await conn.ExecuteAsync("insert into Ejercicio (idcategoria, descripcion) values (@idcategoria, @descripcion)", ejercicio);
                return res;
            }

        }

        public async Task<int> deleteService(cEjercicio ejercicio)
        {
            using (var conn = CreateConnection())
            {
                var res = await conn.ExecuteAsync("delete from Ejercicio Where idejercicio = @idejercicio", ejercicio);
                return res;
            }
        }

        public async Task<cEjercicio> getServiceById(int Id)
        {
            using (var conn = CreateConnection())
            {
                var res = await conn.QueryFirstOrDefaultAsync<cEjercicio>("select * from Ejercicio Where idejercicio = @id", new { id = Id });
                return res;
            }
        }

        public async Task<List<cEjercicio>> getServicelist()
        {
            using (var conn = CreateConnection())
            {
                var res = await conn.QueryAsync<cEjercicio>("Select * from Ejercicio");
                return res.ToList();
            }
        }

        public async Task<int> updateService(cEjercicio ejercicio)
        {
            using (var conn = CreateConnection())
            {
                var res = await conn.ExecuteAsync("update Ejercicio Set idcategoria = @idcategoria, descripcion = @descripcion Where idejercicio = @idejercicio", ejercicio);
                return res;
            }
        }
    }
}
