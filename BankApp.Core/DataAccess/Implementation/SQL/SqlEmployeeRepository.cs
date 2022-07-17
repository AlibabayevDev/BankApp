using BankApp.Core.DataAccess.Abstract;
using BankApp.Core.Domain.Entities;
using BankApp.Core.Extention;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.DataAccess.Implementation.SQL
{
    public class SqlEmployeeRepository : IEmployeeRepository
    {
        private readonly string connectionString;

        public SqlEmployeeRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Delete(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = $"Delete from Employee where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("Id", Id);

                    int affectedCount = cmd.ExecuteNonQuery();

                    return affectedCount == 1;
                }
            }
        }

        public bool Update(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = $"Update Employee set FirstName = @FirstName, Surname = @Surname, Speciality = @Speciality, Salary = @Salary, Address = @Address, Number = @Number, IsDeleted = @IsDeleted where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("Id", employee.Id);
                    cmd.Parameters.AddWithValue("FirstName", employee.FirstName);
                    cmd.Parameters.AddWithValue("Surname", employee.Surname);
                    cmd.Parameters.AddWithValue("Speciality", employee.Speciality);
                    cmd.Parameters.AddWithValue("Salary", employee.Salary);
                    cmd.Parameters.AddWithValue("Address", employee.Address);
                    cmd.Parameters.AddWithValue("Number", employee.Phone);
                    cmd.Parameters.AddWithValue("@IsDeleted", employee.IsDeleted);

                    int affectedCount = cmd.ExecuteNonQuery();

                    return affectedCount == 1; 
                }
            }
        }

        public bool Insert(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = $"Insert into Employee Values(@Name, @Surname, @Number, @Speciality, @BranchId, @Salary, @Address, @IsDeleted)";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", employee.FirstName);
                    cmd.Parameters.AddWithValue("@Surname", employee.Surname);
                    cmd.Parameters.AddWithValue("@Number", employee.Phone);
                    cmd.Parameters.AddWithValue("@Speciality", employee.Speciality);
                    cmd.Parameters.AddWithValue("@BranchId", employee.Branch.Id);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@Address", employee.Address);
                    cmd.Parameters.AddWithValue("@IsDeleted", employee.IsDeleted);

                    int affectedCount = cmd.ExecuteNonQuery();

                    return affectedCount == 1;
                }
            }
        }


        public List<Employee> Get()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = $"select Branches.BranchName, Employee.Id, Employee.FirstName, Employee.Surname,Employee.Speciality,Employee.Salary, Employee.Number,  Employee.Address, Employee.IsDeleted from Employee inner join Branches on Branches.Id = Employee.BranchId where Employee.IsDeleted = 0";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Employee> employees = new List<Employee>();

                    while (reader.Read())
                    {
                        Employee employee = new Employee();

                        employee.Id = (int)reader["Id"];
                        employee.FirstName = Convert.ToString(reader["FirstName"]);
                        employee.Surname = Convert.ToString(reader["Surname"]);
                        employee.Speciality = Convert.ToString(reader["Speciality"]);
                        employee.Salary = Convert.ToDecimal(reader["Salary"]);
                        employee.Phone = Convert.ToString(reader["Number"]);
                        employee.Address = Convert.ToString(reader["Address"]);
                        employee.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                        employee.Branch = new Branch()
                        {
                            //Id = Convert.ToInt32(reader["BranchId"]),
                            BranchName = Convert.ToString(reader["BranchName"]),
                        };

                        employees.Add(employee);
                    }

                    return employees;
                }
            }
        }

        /*public Employee Get(int Id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "select * from Employee where Id= @Id and IsDeleted = 0";
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
        }*/


        public Employee Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "select Branches.BranchName, Employee.Id, Employee.FirstName,Employee.Surname, Employee.Number, Employee.Speciality ,Employee.Salary,Employee.Address,Employee.BranchId from Employee inner join Branches on Employee.BranchId = Branches.Id where  Employee.Id = @ID and Employee.IsDeleted = 0";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("Id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    Employee employee = new Employee();

                    while (reader.Read())
                    {
                        employee.Id = Convert.ToInt32(reader["Id"]);
                        employee.FirstName = Convert.ToString(reader["FirstName"]);
                        employee.Surname = Convert.ToString(reader["Surname"]);
                        employee.Phone = Convert.ToString(reader["Number"]);
                        employee.Speciality = Convert.ToString(reader["Speciality"]);
                        employee.Salary = Convert.ToInt32(reader["Salary"]);
                        employee.Address = Convert.ToString(reader["Address"]);
                        employee.Branch = new Branch()
                        {
                            Id = Convert.ToInt32(reader["BranchId"]),
                            BranchName = Convert.ToString(reader["BranchName"])
                        };
                    }

                    return employee;
                }
            }
        }


        private Employee GetFromReader(SqlDataReader reader)
        {
            return new Employee
            {
                Id = reader.Get<int>("Id"),
                FirstName = reader.Get<string>("FirstName"),
                Surname = reader.Get<string>("Surname"),
                Speciality = reader.Get<string>("Speciality"),
                Phone = reader.Get<string>("Number"),
                Address = reader.Get<string>("Address"),
                IsDeleted = reader.Get<bool>("IsDeleted"),
            };
        }
    }
}
