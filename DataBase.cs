using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace Приложение_консультант_по_подбору_спортивных_секций
{
    public class DataBase
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DMITRLAPTOP;Initial Catalog=SportsRecomendation;Integrated Security=True;Trust Server Certificate=True");

        public void OpenConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
                sqlConnection.Open();
        }
        public void CloseConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
                sqlConnection.Close();
        }

        public SqlConnection GetConnection() { return sqlConnection; }
    }
}
