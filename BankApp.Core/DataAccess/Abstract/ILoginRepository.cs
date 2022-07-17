using BankApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.DataAccess.Abstract
{
    public interface ILoginRepository : ICrudRepository<User>
    {
        User Get(string username);
    }
}
