using BankApp.Core.DataAccess.Abstract;
using BankApp.Core.Domain.Entities;
using BankApp.Core.Extention;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.DataAccess.SQL
{
    internal class SqlLoginRepository : ILoginRepository
    {
        private readonly string connectionString;

        public SqlLoginRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Delete(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string cmdText = $"Delete from Logins where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);

                    int affectedCount = cmd.ExecuteNonQuery();

                    return affectedCount == 1;
                }
            }
        }

        public bool Insert(User login)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string cmdText = $"Insert into Logins values(@Username,@PasswordHash)";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", login.Username);
                    cmd.Parameters.AddWithValue("@PasswordHash", login.PasswordHash);

                    int affectedCount = cmd.ExecuteNonQuery();

                    return affectedCount == 1;
                }
            }
        }

        public List<User> Get()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string cmdText = "select * from Logins";

                using (SqlCommand cmd = new SqlCommand())
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<User> logins = new List<User>();
                    while (reader.Read())
                    {
                        User login = new User();

                        login.Id = (int)reader["Id"];
                        login.Username = Convert.ToString(reader["Username"]);
                        login.PasswordHash = Convert.ToString(reader["PasswordHash"]);
                        logins.Add(login);
                    }

                    return logins;
                }
            }
        }


        public bool Update(User login)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string cmdText = $"Update Logins set Username = @Username, PasswordHash = @PasswordHash where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", login.Id);
                    cmd.Parameters.AddWithValue("@Username", login.Username);
                    cmd.Parameters.AddWithValue("@PasswordHash", login.PasswordHash);

                    int affectedCount = cmd.ExecuteNonQuery();


                    return affectedCount == 1;
                }
            }
        }

        public User Get(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "select * from Logins where Id=@id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("Id", id);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var login = GetFromReader(reader);
                    return login;
                }
                else
                {
                    return null;
                }
            }
        }


        public User Get(string Username)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "select * from Logins where Username = @Username";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", Username);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var login = GetFromReader(reader);
                    return login;
                }
                else
                {
                    return null;
                }
            }
        }


        private User GetFromReader(SqlDataReader reader)
        {
            return new User
            {
                Id = reader.Get<int>("Id"),
                Username = reader.Get<string>("Username"),
                PasswordHash = reader.Get<string>("PasswordHash"),
            };
        }
    }
}
