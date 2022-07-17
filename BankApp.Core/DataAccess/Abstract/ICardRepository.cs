using BankApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.DataAccess.Abstract
{
    public interface ICardRepository : ICrudRepository<Card>
    {
        
    }
}
