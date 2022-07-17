using BankApp.Core.DataAccess.Abstract;
using BankApp.Core.DataAccess.Implementation.SQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.DataAccess.SQL
{
    internal class SqlUnitOfWork : IUnitOfWork
    {
        private readonly string connectionString1;

        public SqlUnitOfWork(string connectionString2)
        {
            connectionString1 = connectionString2;
        }

        public IClientRepository ClientRepository => new SqlClientRepository(connectionString1);
        public ICardRepository CardRepository => new SqlCardRepository(connectionString1);
        public ILoginRepository LoginRepository => new SqlLoginRepository(connectionString1);
        public IExchangeRepository ExchangeRepository => new SqlExchangeRepository(connectionString1);
        public ICreditRepository CreditRepository => new SqlCreditRepository(connectionString1);
        public IEmployeeRepository EmployeeRepository => new SqlEmployeeRepository(connectionString1);
        public IBranchRepository BranchesRepository => new SqlBranchRepository(connectionString1);
    }
}
