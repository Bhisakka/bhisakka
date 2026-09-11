using System;
using System.Configuration;
using Npgsql;

namespace Bhisakka.DataAccess
{
    public static class DatabaseHelper
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["BhisakkaDb"].ConnectionString;

        public static NpgsqlConnection GetConnection()
        {
            var connection = new NpgsqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}