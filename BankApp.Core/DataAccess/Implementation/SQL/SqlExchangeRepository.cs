using BankApp.Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BankApp.Core.Domain.Entities;
using BankApp.Core.Extention;

namespace BankApp.Core.DataAccess.Implementation.SQL
{
    public class SqlExchangeRepository : IExchangeRepository
    {
        private readonly string connectionString;

        public SqlExchangeRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Delete(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = $"Delete from Exchange where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("Id", Id);

                    int affectedCount = cmd.ExecuteNonQuery();

                    return affectedCount == 1;
                }
            }
        }

        public bool Insert(Exchange exchange)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = $"Insert into Exchange Values(@IdClient, @Phone, @AmountToExchange, @AmountFromExchange, @ConvertFromCurrency, @ConvertToCurrency, @Date, @IsDeleted )";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@IdClient", exchange.Client.Id);
                    cmd.Parameters.AddWithValue("@Phone", exchange.Phone);
                    cmd.Parameters.AddWithValue("@AmountToExchange", exchange.AmountToExchange);
                    cmd.Parameters.AddWithValue("@AmountFromExchange", exchange.AmountFromExchange);
                    cmd.Parameters.AddWithValue("@ConvertFromCurrency", exchange.ConvertFromCurrency);
                    cmd.Parameters.AddWithValue("@ConvertToCurrency", exchange.ConvertToCurrency);
                    cmd.Parameters.AddWithValue("@Date", exchange.Date);
                    cmd.Parameters.AddWithValue("@IsDeleted", exchange.IsDeleted);
                    int affectedCount = cmd.ExecuteNonQuery();

                    return affectedCount == 1;
                }
            }
        }

        public List<Exchange> Get()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //  string cmdText = "select * from Exchange where IsDeleted = 0";
                //,Clients.Surname,Clients.FIN

                string cmdText = "select Clients.Name,Exchange.Id, Exchange.Phone, Exchange.AmountFromExchange, Exchange.AmountToExchange,  Exchange.ConvertFromCurrency, Exchange.ConvertToCurrency, Exchange.Date, Exchange.IsDeleted  from Exchange inner join Clients on Clients.Id = Exchange.IdClient where Exchange.IsDeleted = 0";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exchange> exchanges = new List<Exchange>();

                    while (reader.Read())
                    {
                        Exchange exchange = new Exchange();
                        exchange.Id = (int)reader["Id"];
                        exchange.Phone = Convert.ToString(reader["Phone"]);
                        exchange.AmountToExchange = (int)reader["AmountToExchange"];
                        exchange.AmountFromExchange = (int)reader["AmountFromExchange"];
                        exchange.ConvertFromCurrency = Convert.ToString(reader["ConvertFromCurrency"]);
                        exchange.ConvertToCurrency = Convert.ToString(reader["ConvertToCurrency"]);
                        exchange.Date = Convert.ToDateTime(reader["Date"]);
                        exchange.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                        exchange.Client = new Client()
                        {
                            Name = Convert.ToString(reader["Name"])
                        };

                        exchanges.Add(exchange);
                    }

                    return exchanges;
                }
            }
        }

        public bool Update(Exchange exchange)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = $"Update Exchange set Phone = @Phone, AmountToExchange = @AmountToExchange, AmountFromExchange = @AmountFromExchange, ConvertFromCurrency = @ConvertFromCurrency, ConvertToCurrency = @ConvertToCurrency, Date = @Date, IsDeleted = @IsDeleted  where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", exchange.Id);
                    cmd.Parameters.AddWithValue("@IdCLient", exchange.IdClient);
                    cmd.Parameters.AddWithValue("@Phone", exchange.Phone);
                    cmd.Parameters.AddWithValue("@AmountToExchange", exchange.AmountToExchange);
                    cmd.Parameters.AddWithValue("@AmountFromExchange", exchange.AmountFromExchange);
                    cmd.Parameters.AddWithValue("@ConvertFromCurrency", exchange.ConvertFromCurrency);
                    cmd.Parameters.AddWithValue("@ConvertToCurrency", exchange.ConvertToCurrency);
                    cmd.Parameters.AddWithValue("@Date", exchange.Date);
                    cmd.Parameters.AddWithValue("@IsDeleted", exchange.IsDeleted);
                    int affectedCount = cmd.ExecuteNonQuery();


                    return affectedCount == 1;
                }
            }
        }

        private Exchange GetFromReader(SqlDataReader reader)
        {
            return new Exchange
            {
                Id = reader.Get<int>("Id"),
                Phone = reader.Get<string>("Phone"),
                AmountToExchange = reader.Get<int>("AmountToExchange"),
                AmountFromExchange = reader.Get<int>("AmountFromExchange"),
                ConvertFromCurrency = reader.Get<string>("ConvertFromCurrency"),
                ConvertToCurrency = reader.Get<string>("ConvertToCurrency"),
                Date = reader.Get<DateTime>("Date"),
                IsDeleted = reader.Get<bool>("IsDeleted"),
            };
        }

        public Exchange Get(int Id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //string query = "select * from Exchange where Id = @Id and IsDeleted = 0";
                string query = "select Clients.Name,Exchange.IdClient, Exchange.Id, Exchange.Phone, Exchange.AmountFromExchange, Exchange.AmountToExchange,  Exchange.ConvertFromCurrency, Exchange.ConvertToCurrency, Exchange.Date, Exchange.IsDeleted from Exchange inner join Clients on Clients.Id = Exchange.IdClient where Exchange.Id = @ID and Exchange.IsDeleted = 0";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("Id", Id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    Exchange exchanges = new Exchange();

                    while (reader.Read())
                    {
                        exchanges.Id = (int)reader["Id"];
                        exchanges.IdClient = Convert.ToInt32(reader["IdClient"]);
                        exchanges.Phone = Convert.ToString(reader["Phone"]);
                        exchanges.AmountToExchange = (int)reader["AmountToExchange"];
                        exchanges.AmountFromExchange = (int)reader["AmountFromExchange"];
                        exchanges.ConvertFromCurrency = Convert.ToString(reader["ConvertFromCurrency"]);
                        exchanges.ConvertToCurrency = Convert.ToString(reader["ConvertToCurrency"]);
                        exchanges.Date = Convert.ToDateTime(reader["Date"]);
                        exchanges.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                        exchanges.Client = new Client()
                        {
                            Id = Convert.ToInt32(reader["IdClient"]),
                            Name = Convert.ToString(reader["Name"])
                        };
                    }

                    return exchanges;
                }
            }
        }
    }
}
