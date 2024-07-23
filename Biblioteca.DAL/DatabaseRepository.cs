using Biblioteca.DAL.Interfaces;
using Dapper;
using Microsoft.Extensions.Options;
using Biblioteca.Common;
using System.Data.SqlClient;

namespace Biblioteca.DAL
{
    internal class DatabaseRepository : IDatabaseRepository
    {
        private readonly string connectionString;

        public DatabaseRepository(IOptions<AppSettings> appSettings)
        {
            connectionString = appSettings.Value.ConnectionString;
        }

        public async Task<bool> DeleteAsync(string storeProcedure, DynamicParameters? parameters = null)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    bool result = await connection.QuerySingleOrDefaultAsync<bool>(storeProcedure, parameters);
                    connection.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en DeleteAsync : " + ex.Message);
            }
        }

        public async Task<List<T>> GetDataByQueryAsync<T>(string query, DynamicParameters? parameters = null)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString)) { 
                    connection.Open();
                    var result = await connection.QueryAsync<T>(query, parameters);
                    connection.Close();
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en GetDataByQueryAsync : " + ex.Message);
            }
        }

        public async Task<int> InsertAsync(string storeProcedure, DynamicParameters? parameters = null)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    int result = await connection.QuerySingleOrDefaultAsync<int>(storeProcedure, parameters);
                    connection.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en InsertAsync : " + ex.Message);
            }
        }

        public async Task<T?> UpdateAsync<T>(string storeProcedure, DynamicParameters? parameters = null)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<T>(storeProcedure, parameters);
                    connection.Close();
                    if(result != null && result.Any())
                    {
                        return result.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en UpdateAsync : " + ex.Message);
            }
            return default;
        }
    }
}
