  using BankApp.Core.DataAccess.Abstract;
using BankApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.DataAccess.SQL
{
    public class SqlCardRepository : ICardRepository
    {   
        private readonly string connectionString;

        public SqlCardRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Insert(Card card)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string cmdText = $"Insert into Card values(@ClientId, @TypeCard, @CardNumber, @EndDate,@IsDeleted)";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@ClientId", card.Client.Id);
                    cmd.Parameters.AddWithValue("@TypeCard", card.TypeCard);
                    cmd.Parameters.AddWithValue("@CardNumber", card.CardNumber);
                    cmd.Parameters.AddWithValue("@EndDate", card.EndDate);
                    cmd.Parameters.AddWithValue("@IsDeleted", card.IsDeleted);
                    int affectedCount = cmd.ExecuteNonQuery();

                    return affectedCount == 1;
                }
            }
        }

        public bool Delete(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = $"Delete from Card where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("Id", Id);

                    int affectedCount = cmd.ExecuteNonQuery();

                    return affectedCount == 1;
                }
            }
        }

        public bool Update(Card card)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = $"Update Card set ClientId = @ClientId, TypeCard = @TypeCard, CardNumber = @CardNumber, EndDate = @EndDate, IsDeleted = @IsDeleted where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", card.Id);
                    cmd.Parameters.AddWithValue("@ClientId", card.ClientId);
                    cmd.Parameters.AddWithValue("@TypeCard", card.TypeCard);
                    cmd.Parameters.AddWithValue("@CardNumber", card.CardNumber);
                    cmd.Parameters.AddWithValue("@EndDate", card.EndDate);
                    cmd.Parameters.AddWithValue("@IsDeleted", card.IsDeleted);
                    int affectedCount = cmd.ExecuteNonQuery();

                    return affectedCount == 1;
                }
            }
        }

        public List<Card> Get()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string cmdText = "select Clients.Id as ClientId, Clients.Name,Card.Id,Card.TypeCard,Card.CardNumber,Card.EndDate,Card.IsDeleted from Card inner join Clients on Clients.Id = Card.ClientId where Card.IsDeleted = 0";
               
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Card> cards = new List<Card>();

                    while (reader.Read())
                    {
                        Card card = new Card();

                        card.ClientId = (int)reader["ClientId"];
                        card.Id = Convert.ToInt32(reader["Id"]);
                        card.TypeCard = Convert.ToString(reader["TypeCard"]);
                        card.CardNumber = Convert.ToString(reader["CardNumber"]);
                        card.EndDate = Convert.ToDateTime(reader["EndDate"]);
                        card.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                        card.Client = new Client()
                        {
                            Id = card.ClientId,
                            Name = Convert.ToString(reader["Name"]),
                        };

                        cards.Add(card);
                    }

                    return cards;
                }
            }
        }

        public Card Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //  string cmdText = "select * from Card where IsDeleted = 0";
                string cmdText = "select Clients.Name, Card.Id, Card.TypeCard, Card.ClientId, Card.CardNumber,Card.EndDate,Card.IsDeleted from Card inner join Clients on Clients.Id = Card.ClientId where  Card.Id = @id and Card.IsDeleted = 0";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("Id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    Card card = new Card();

                    while (reader.Read())
                    {
                        card.Id = Convert.ToInt32(reader["Id"]);
                        card.ClientId = Convert.ToInt32(reader["ClientId"]);
                        card.TypeCard = Convert.ToString(reader["TypeCard"]);
                        card.CardNumber = Convert.ToString(reader["CardNumber"]);
                        card.EndDate = Convert.ToDateTime(reader["EndDate"]);
                        card.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                        card.Client = new Client
                        {
                            Id = Convert.ToInt32(reader["ClientId"]),
                            Name = Convert.ToString(reader["Name"])
                        };
                    }

                    return card;
                }
            }
        }
    }
}
