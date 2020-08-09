using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1.Models
{
    public class DataProvider
    {
        public static SqlConnection sqlConnection = null;
        public SqlConnection GetSqlConnectionProvider()
        {

            if ((sqlConnection == null) || (sqlConnection.State != ConnectionState.Open))
            {
                try
                {
                    SqlConnection conn = sqlConnection = new SqlConnection(Startup.ConnectionString);
                    sqlConnection = conn;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return sqlConnection;
        }
    }
}
