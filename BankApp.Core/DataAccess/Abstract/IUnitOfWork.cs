using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.DataAccess.Abstract
{
    public interface IUnitOfWork
    {
        IClientRepository ClientRepository { get; }
        ICardRepository CardRepository { get; }
        ILoginRepository LoginRepository { get; }
        IExchangeRepository ExchangeRepository { get; }
        ICreditRepository CreditRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IBranchRepository BranchesRepository { get; }
    }
}
