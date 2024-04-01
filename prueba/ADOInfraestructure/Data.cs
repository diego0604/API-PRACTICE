using DataAccess.Interfaces;

using System.Data;
using System.Data.SqlClient;


namespace DataAccess
{
    public class Data : IData, IDisposable
    {
        private Exception ex = null;

        private string _connString;

        public Data(string connectionString)
        {
            _connString = connectionString;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
        }



        public async Task<DataTable> ConsultAsync(string sql)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandText = sql;
                    DataTable dt = new DataTable();
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    try
                    {
                        var reader = await command.ExecuteReaderAsync();
                        dt.Load(reader);
                    }
                    catch (Exception ex)
                    {
                        this.ex = ex;
                        dt = null;
                        System.Diagnostics.Trace.WriteLine(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                        command.Dispose();
                    }
                    return dt;
                }
            }
        }
    }
      
      


    public class TableResponse
    {
        public DataTable dtObject { get; set; }

        public DataSet dsObject { get; set; }

    }
}





