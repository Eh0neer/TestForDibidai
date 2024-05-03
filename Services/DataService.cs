using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace TestForDibiai.Services
{
    public class DataService
    {
        private readonly string connectionString;

        public DataService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<T> ExecuteQuery<T>(string sqlQuery, object param = null)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<T>(sqlQuery, param).ToList();
            }
        }

        public int ExecuteCommand(string sqlCommand, object param = null)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Execute(sqlCommand, param);
            }
        }
    }
}
