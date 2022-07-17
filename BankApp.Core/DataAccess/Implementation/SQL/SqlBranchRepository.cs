using BankApp.Core.DataAccess.Abstract;
using BankApp.Core.Domain.Entities;
using BankApp.Core.Extention;
using System.Data.SqlClient;

namespace BankApp.Core.DataAccess.Implementation.SQL
{
    public class SqlBranchRepository : IBranchRepository
    {
        private readonly string connectionString;
        public SqlBranchRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public bool Delete(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string cmdText = $"Delete from Branches where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);

                    int affectedCount = cmd.ExecuteNonQuery();

                    return affectedCount == 1;
                }
            }
        }


        public bool Insert(Branch branch)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string cmdText = $"Insert into Branches values(@BranchName,@Adress,@BeginWorkTime,@EndWorkTime,@Phone,@CountWorkers,@IsDeleted)";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@BranchName", branch.BranchName);
                    cmd.Parameters.AddWithValue("@Adress", branch.Adress);
                    cmd.Parameters.AddWithValue("@BeginWorkTime", branch.BeginWorkTime);
                    cmd.Parameters.AddWithValue("@EndWorkTime", branch.EndWorkTime);
                    cmd.Parameters.AddWithValue("@Phone", branch.Phone);
                    cmd.Parameters.AddWithValue("@CountWorkers", branch.CountWorkers);
                    cmd.Parameters.AddWithValue("@IsDeleted", branch.IsDeleted);

                    int affectedCount = cmd.ExecuteNonQuery();

                    return affectedCount == 1;
                }
            }
        }


        public List<Branch> Get()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "select * from Branches where IsDeleted = 0";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Branch> branches = new List<Branch>();

                    while (reader.Read())
                    {
                        Branch branch = new Branch();

                        branch.Id = (int)reader["Id"];
                        branch.BranchName = Convert.ToString(reader["BranchName"]);
                        branch.Adress = Convert.ToString(reader["Adress"]);
                        branch.BeginWorkTime = Convert.ToString(reader["BeginWorkTime"]);
                        branch.EndWorkTime = Convert.ToString(reader["EndWorkTime"]);
                        branch.CountWorkers = Convert.ToInt32(reader["CountWorkers"]);
                        branch.Phone = Convert.ToString(reader["Phone"]);
                        branches.Add(branch);
                    }

                    return branches;
                }
            }
        }


        public bool Update(Branch branch)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string cmdText = $"Update Branches set BranchName = @BranchName, Adress = @Adress, BeginWorkTime = @BeginWorkTime, EndWorkTime = @EndWorkTime, CountWorkers = @CountWorkers, Phone = @Phone, IsDeleted=@IsDeleted where id = @ID";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("Id", branch.Id);
                    cmd.Parameters.AddWithValue("@BranchName", branch.BranchName);
                    cmd.Parameters.AddWithValue("@Adress", branch.Adress);
                    cmd.Parameters.AddWithValue("@BeginWorkTime", branch.BeginWorkTime);
                    cmd.Parameters.AddWithValue("@EndWorkTime", branch.EndWorkTime);
                    cmd.Parameters.AddWithValue("@CountWorkers", branch.CountWorkers);
                    cmd.Parameters.AddWithValue("@Phone", branch.Phone);
                    cmd.Parameters.AddWithValue("@IsDeleted", branch.IsDeleted);
                    int affectedCount = cmd.ExecuteNonQuery();


                    return affectedCount == 1;
                }
            }
        }


        public Branch Get(int Id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "select * from Branches where Id= @Id and IsDeleted = 0";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("Id", Id);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var bank = GetFromReader(reader);
                    return bank;
                }
                else
                {
                    return null;
                }
            }
        }


        private Branch GetFromReader(SqlDataReader reader)
        {
            return new Branch
            {
                Id = reader.Get<int>("Id"),
                BranchName = reader.Get<string>("BranchName"),
                Adress = reader.Get<string>("Adress"),
                BeginWorkTime = reader.Get<string>("BeginWorkTime"),
                EndWorkTime = reader.Get<string>("EndWorkTime"),
                CountWorkers = reader.Get<int>("CountWorkers"),
                Phone = reader.Get<string>("Phone"),
            };
        }
    }
}
