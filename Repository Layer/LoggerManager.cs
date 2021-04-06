using System;
using System.Data.SqlClient;

using Dapper;

using EntitiesLayer;

namespace RepositoryLayer
{
    public class LoggerManager : ILoggerManager, IDisposable
    {
        private readonly string _connectionstring = "DefaultConnection";

        public bool Insert(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                string sql = "INSERT INTO LogData (entity) Values (@value);";

                try
                {
                    using (var connection = new SqlConnection(_connectionstring))
                    {
                        var result = connection.Execute(sql, value);
                    }

                    return true;
                }
                catch { }
            }

            return false;
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
