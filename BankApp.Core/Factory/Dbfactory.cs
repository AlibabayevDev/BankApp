using BankApp.Core.DataAccess.Abstract;
using BankApp.Core.DataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.Factory
{
    public class DbFactory
    {
        public static IUnitOfWork Create(string connectionString)
        {
            return new SqlUnitOfWork(connectionString);
        }
    }
}
