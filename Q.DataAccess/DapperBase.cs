using Dapper;
using MySql.Data.MySqlClient;
using Q.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Q.DataAccess
{
    public class DapperBase<T> : IBaseRepository<T> where T : BaseEntity
    {
        private IEnumerable<PropertyInfo> GetProperties => typeof(T).GetProperties();
        protected readonly string _connection;

        public DapperBase(string connectionString)
        {
            _connection = connectionString;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using (var connection = new MySqlConnection(_connection))
            {
                return await connection.QueryAsync<T>($"SELECT * FROM {typeof(T).Name.ToLower()}");
            }
        }


        public async Task<T> GetByIdAsync(int id)
        {
            using (var connection = new MySqlConnection(_connection))
            {
                var result =
                    await connection.QuerySingleOrDefaultAsync<T>(
                        $"SELECT * FROM {typeof(T).Name.ToLower()} WHERE Id=@Id", new { Id = id });
                return result;
            }
        }



        public T Filter(string column, object value)
        {
            using (var connection = new MySqlConnection(_connection))
            {
                var result =
                    connection.QuerySingleOrDefault<T>($"SELECT * FROM {typeof(T).Name.ToLower()} WHERE {column}=@arg",
                        new { arg = value });
                return result;
            }
        }

        public IEnumerable<T> FilterAll(string column, object value)
        {
            using (var connection = new MySqlConnection(_connection))
            {
                var result = connection.Query<T>($"SELECT * FROM {typeof(T).Name.ToLower()} WHERE {column}=@arg",
                    new { arg = value });
                return result;
            }
        }


        public async Task DeleteByIdAsync(int id)
        {
            using (var connection = new MySqlConnection(_connection))
            {
                await connection.ExecuteAsync($"DELETE FROM {typeof(T).Name.ToLower()} WHERE Id=@Id", new { Id = id });
            }
        }

        public async Task<T> InsertAsync(T t)
        {
            var insertQuery = GenerateInsertQuery(typeof(T));

            using (var connection = new MySqlConnection(_connection))
            {
                await connection.ExecuteAsync(insertQuery, t);
                t.Id = await connection.ExecuteScalarAsync<int>("select LAST_INSERT_ID()");
                return t;
            }
        }


        public async Task UpdateAsync(T t)
        {
            var updateQuery = GenerateUpdateQuery(typeof(T));

            using (var connection = new MySqlConnection(_connection))
            {
                await connection.ExecuteAsync(updateQuery, t);
            }
        }


        private static List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore"
                    select prop.Name).ToList();
        }

        protected string GenerateInsertQuery(Type t)
        {
            var insertQuery = new StringBuilder($"INSERT INTO {t.Name.ToLower()} ");

            insertQuery.Append("(");

            var properties = GenerateListOfProperties(GetProperties);
            properties.ForEach(prop => { insertQuery.Append($"{prop},"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") VALUES (");

            properties.ForEach(prop => { insertQuery.Append($"@{prop},"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(")");

            return insertQuery.ToString();
        }

        protected string GenerateUpdateQuery(Type t)
        {
            var updateQuery = new StringBuilder($"UPDATE {t.Name.ToLower()} SET ");
            var properties = GenerateListOfProperties(GetProperties);

            properties.ForEach(property =>
            {
                if (!property.Equals("Id"))
                {
                    updateQuery.Append($"{property}=@{property},");
                }
            });

            updateQuery.Remove(updateQuery.Length - 1, 1); //remove last comma
            updateQuery.Append(" WHERE Id=@Id");

            return updateQuery.ToString();
        }
    }
}
