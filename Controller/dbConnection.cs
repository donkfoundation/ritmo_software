using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net;

namespace hotel_nn
{
    public class dbConnection
    {

        public static string db_name = "ritmo_software";
        public static string server_name = @"(local)";
        public SqlConnection conexString = new SqlConnection($"Server={server_name};Database={db_name};Trusted_connection=True");
        // Aquí se inicializa la cadena de conexión que se irá pasando de formulario en formulario.
        public dbConnection() 
        {

        }

        public void openConnection()
        {
            if (conexString.State == System.Data.ConnectionState.Closed)
            {
                conexString.Open();
            }
            else if (conexString.State == System.Data.ConnectionState.Open)
            {

            }
        }

        public void closeConnection()
        {
            if (conexString.State == System.Data.ConnectionState.Open)
            {
                conexString.Close();
            } 
            else if (conexString.State == System.Data.ConnectionState.Closed)
            {

            }
        }
    }
}
