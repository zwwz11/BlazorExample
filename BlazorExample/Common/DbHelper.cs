using Microsoft.Data.SqlClient;
using System.Data;

namespace BlazorExample.Common
{
    public class DbHelper
    {
        private static readonly SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder("Server=.; Database=application; Trusted_Connection=True; Trust Server Certificate=True;");

        public static DataTable GetDataTable(string sql)
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

        public static DataTable GetDataTable(string procedureName, Dictionary<string, dynamic> param)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(procedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        param.ToList().ForEach(x => command.Parameters.Add(new SqlParameter(x.Key, x.Value)));
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

        public static void ExecuteSQL(string sql)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public static void ExecuteSQL(string procedureName, Dictionary<string, dynamic> param)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(procedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        param.ToList().ForEach(x => command.Parameters.Add(new SqlParameter(x.Key, x.Value)));
                        command.ExecuteNonQuery();
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
