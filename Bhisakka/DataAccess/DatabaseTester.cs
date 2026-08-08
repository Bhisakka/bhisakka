using System;
using Npgsql;

namespace Bhisakka.DataAccess
{
    public static class DatabaseTester
    {
        public static string PingDatabase()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    string sql = "SELECT version();";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        string version = cmd.ExecuteScalar()?.ToString();
                        return $"Connection Successful!\n\nServer Info: {version}";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Connection Failed:\n\n{ex.Message}";
            }
        }
    }
}