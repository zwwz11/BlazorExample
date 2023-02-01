using BlazorExample.Services;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BlazorExample.Common
{
    public class DbHelper
    {
        private readonly SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder("Server=.; Database=application; Trusted_Connection=True; Trust Server Certificate=True;");

        public DataTable GetDataTable(string sql)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new();
                            adapter.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void ExecuteSQL(string sql)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            
                            DataTable dt = new();
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
