using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BlazorDapperSPA.Data
{
    public class UserCollectionService : IUserCollectionService
    {
        private readonly SqlConnectionConfiguration _configuration;
        public UserCollectionService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> CreateCollection(UserCollection collection)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = @"insert into dbo.Collection (Name,Category) values (@Name,@Category)";
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync(query, new { collection.Name, collection.Category }, commandType: CommandType.Text);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return true;
        }
        public async Task<bool> DeleteCollection(int id)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = @"delete from dbo.Collection where Id=@Id";
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync(query, new { id }, commandType: CommandType.Text);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return true;
        }
        public async Task<bool> EditCollection(int id, UserCollection collection)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = @"update dbo.Collection set Name = @Name, Category = @Category where Id=@Id";
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync(query, new { collection.Name, collection.Category, id }, commandType: CommandType.Text);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return true;
        }
        public async Task<IEnumerable<UserCollection>> GetCollections()
        {
            IEnumerable<UserCollection> collections;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = @"select * from dbo.Collection";

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    collections = await conn.QueryAsync<UserCollection>(query);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }

            }
            return collections;
        }
        public async Task<UserCollection> SingleCollection(int id)
        {
            UserCollection collection = new UserCollection();

            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = @"select * from dbo.Collection where Id =@Id";

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    collection = await conn.QueryFirstOrDefaultAsync<UserCollection>(query, new { id }, commandType: CommandType.Text);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return collection;
        }
    }
}
