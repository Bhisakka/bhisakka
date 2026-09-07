using Bhisakka.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bhisakka.DataAccess
{
    internal class AuthRepository
    {
        public User GetUserByCredentials(string username, string hash)
        {
            string query = @"
                SELECT u.user_id, u.username, u.full_name, u.is_active, r.role_id, r.role_name 
                FROM users u 
                JOIN roles r ON r.role_id = u.role_id 
                WHERE u.username = @username 
                  AND u.password_hash = @hash 
                  AND u.is_active = true;";

            using (var conn = DatabaseHelper.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@hash", hash);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User(
                                reader.GetInt32(reader.GetOrdinal("user_id")),
                                reader.GetString(reader.GetOrdinal("username")),
                                reader.GetString(reader.GetOrdinal("full_name")),
                                reader.GetBoolean(reader.GetOrdinal("is_active")),
                                new Role(
                                    reader.GetInt32(reader.GetOrdinal("role_id")),
                                    reader.GetString(reader.GetOrdinal("role_name"))
                                )
                            );
                        }
                    }
                }
            }

            return null;
        }
    }
}
