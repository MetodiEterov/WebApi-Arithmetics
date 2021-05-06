using System;
using System.Data.SqlClient;

using Dapper;

using EntitiesLayer;

namespace RepositoryLayer
{
    /// <summary>
    /// LoggerManager class is responisble for adding log messages to the storage
    /// </summary>
    public class LoggerManager : ILoggerManager, IDisposable
    {
        private readonly string _connectionstring = "DefaultConnection";

        /// <summary>
        /// Insert method using Dapper functionality
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Dispose method
        /// </summary>
        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
