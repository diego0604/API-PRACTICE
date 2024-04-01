using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess
{
    /// <summary>
    /// Descripción breve de Connection
    /// </summary>
    class Connection
    {
        public SqlConnection connectionDB;

        public Connection(string connectionString)
        {
            // Modificado para realizar el procedimiento de Vendamas
            connectionDB = new SqlConnection(strConnMSSQL(connectionString));
        }


        public void OpenConnection()
        {
            try
            {
                if (connectionDB.State == ConnectionState.Broken || connectionDB.State == ConnectionState.Closed)
                    connectionDB.Open();
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine("Error al abrir la conexión " + e.Message);
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (connectionDB.State == ConnectionState.Open)
                {
                    connectionDB.Close();
                    connectionDB.Dispose();
                    connectionDB = null;
                    GC.SuppressFinalize(this);
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine("Error al cerrar la conexión " + e.Message);
            }
        }

        //Metodos duplicados de Tools 

        public string strConnMSSQL(string connectionString)
        {

            return connectionString;
        }


    }
}
