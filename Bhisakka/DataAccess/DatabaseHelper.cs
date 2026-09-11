using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using Npgsql;

namespace Bhisakka.DataAccess
{
    public static class DatabaseHelper
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["BhisakkaDb"].ConnectionString;

        public static NpgsqlConnection GetConnection()
        {
            var connection = new NpgsqlConnection(ConnectionString);
            
            connection.ProvideClientCertificatesCallback += (certs) =>
            {
                X509Certificate2 cert = new X509Certificate2("client.pfx", "KusalDhananjaya");
                certs.Add(cert);
            };

            connection.UserCertificateValidationCallback += (sender, cert, chain, errors) =>
            {
                return true;
            };

            connection.Open();
            return connection;
        }
    }
}