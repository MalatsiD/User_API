using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace User_API.Data
{
    public class DataConnection : IDisposable
    {
        protected IDbConnection dbConnection;

        public DataConnection()
        {
            string connectionString = "";
            dbConnection = new SqlConnection(connectionString);
        }

        public void Dispose()
        {
            dbConnection.Dispose();
        }
    }
}
