using BankApp.Core.DataAccess.Abstract;
using BankApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.DataAccess.Implementation.SQL
{
    public class SqlCreditRepository : ICreditRepository
    {
        private readonly string connectionString;

        public SqlCreditRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }



        public bool Insert(Credit credit)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string cmdText = $"Insert into Credit values(@Amount, @CreditPercent, @AmountReturn, @IsDeleted,@GiveDate,@ReturnDate,@ClientId,@BranchId)";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Amount", credit.Amount);
                    cmd.Parameters.AddWithValue("@CreditPercent", credit.CreditPercent);
                    cmd.Parameters.AddWithValue("@AmountReturn", credit.AmountReturn);
                    cmd.Parameters.AddWithValue("IsDeleted", credit.IsDeleted);
                    cmd.Parameters.AddWithValue("GiveDate", credit.GiveDate);
                    cmd.Parameters.AddWithValue("ReturnDate", credit.ReturnDate);
                    cmd.Parameters.AddWithValue("@ClientId", credit.Client.Id);
                    cmd.Parameters.AddWithValue("@BranchId", credit.Branch.Id);
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
                string cmdText = $"Delete from Credit where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("Id", Id);

                    int affectedCount = cmd.ExecuteNonQuery();

                    return affectedCount == 1;
                }
            }
        }


        public bool Update(Credit credit)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); 
                string cmdText = $"Update Credit set Amount = @Amount, CreditPercent = @CreditPercent, AmountReturn = @AmountReturn, IsDeleted = @IsDeleted, GiveDate =@GiveDate, ReturnDate=@ReturnDate,ClientId=@ClientId, BranchId=@BranchId where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("Id", credit.Id);
                    cmd.Parameters.AddWithValue("@Amount", credit.Amount);
                    cmd.Parameters.AddWithValue("@CreditPercent", credit.CreditPercent);
                    cmd.Parameters.AddWithValue("@AmountReturn", credit.AmountReturn);
                    cmd.Parameters.AddWithValue("IsDeleted", credit.IsDeleted);
                    cmd.Parameters.AddWithValue("GiveDate", credit.GiveDate);
                    cmd.Parameters.AddWithValue("ReturnDate", credit.ReturnDate);
                    cmd.Parameters.AddWithValue("@ClientId", credit.Client.Id);
                    cmd.Parameters.AddWithValue("@BranchId", credit.Branch.Id);
                    int affectedCount = cmd.ExecuteNonQuery();

                    return affectedCount == 1;
                }
            }
        }


        public List<Credit> Get()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //  string cmdText = "select * from Credit where IsDeleted = 0";
                string cmdText = "select Branches.BranchName,Clients.Name, Credit.Id, Credit.Amount,Credit.CreditPercent, Credit.AmountReturn, Credit.IsDeleted ,Credit.GiveDate,Credit.ReturnDate, Credit.ClientId, Credit.BranchId from Credit " +
                    "inner join Branches on Credit.BranchId = Branches.Id " +
                    "inner join Clients on Credit.ClientId = Clients.Id  where Credit.IsDeleted = 0";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Credit> credits = new List<Credit>();

                    while (reader.Read())
                    {
                        Credit credit = new Credit();
                        credit.Branch = new Branch()
                        {
                            BranchName = Convert.ToString(reader["BranchName"])
                        };
                        credit.Id = Convert.ToInt32(reader["Id"]);
                        credit.Amount = Convert.ToDouble(reader["Amount"]);
                        credit.CreditPercent = Convert.ToDouble(reader["CreditPercent"]);
                        credit.AmountReturn = Convert.ToDouble(reader["AmountReturn"]);
                        credit.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                        credit.GiveDate = Convert.ToDateTime(reader["GiveDate"]);
                        credit.ReturnDate = Convert.ToDateTime(reader["ReturnDate"]);
                        credit.BranchId = Convert.ToInt32(reader["BranchId"]);
         
                        credit.Client = new Client()
                        {
                            Name = Convert.ToString(reader["Name"])
                        };
                        credits.Add(credit);
                    }

                    return credits;
                }
            }
        }

        public Credit Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
               // string cmdText = "select * from Credit where  Id = @Id and IsDeleted = 0";
                string cmdText = "select Branches.BranchName,Clients.Name, Credit.Id, Credit.Amount,Credit.CreditPercent, Credit.AmountReturn, Credit.IsDeleted ,Credit.GiveDate,Credit.ReturnDate, Credit.ClientId, Credit.BranchId from Credit " +
                   "inner join Branches on Credit.BranchId = Branches.Id " +
                   "inner join Clients on Credit.ClientId = Clients.Id  where  Credit.Id = @Id and Credit.IsDeleted = 0";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("Id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    Credit credit = new Credit();

                    while (reader.Read())
                    {
                        credit.Id = Convert.ToInt32(reader["Id"]);
                        credit.Amount = Convert.ToInt32(reader["Amount"]);
                        credit.CreditPercent = Convert.ToDouble(reader["CreditPercent"]);
                        credit.AmountReturn = Convert.ToDouble(reader["AmountReturn"]);
                        credit.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                        credit.GiveDate = Convert.ToDateTime(reader["GiveDate"]);
                        credit.ReturnDate = Convert.ToDateTime(reader["ReturnDate"]);
                        credit.BranchId = Convert.ToInt32(reader["BranchId"]);
                        credit.Branch = new Branch
                        {
                            Id = Convert.ToInt32(reader["BranchId"]),
                            BranchName = Convert.ToString(reader["BranchName"])
                        };
                        credit.Client = new Client()
                        {
                            Id = Convert.ToInt32(reader["ClientId"]),
                            Name = Convert.ToString(reader["Name"])
                        };
                    }

                    return credit;
                }
            }
        }
    }
}
