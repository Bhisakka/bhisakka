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

                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        var version = cmd.ExecuteScalar()?.ToString();
                        return $"Local Connection Successful!\n\nServer Info: {version}";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Local Connection Failed:\n\n{ex.Message}";
            }
        }
    }
}