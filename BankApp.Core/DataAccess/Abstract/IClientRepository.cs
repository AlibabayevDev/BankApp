using BankApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.DataAccess.Abstract
{
    public interface IClientRepository : ICrudRepository<Client>
    {
        List<Client> GetRestore();
        Client GetRestore(int id);
        List<Client> GetCard(int id);
        List<Client> GetCredits(int id);

        Client GetCredit(int id);
        //Client GetCard(int id);
    }
}
