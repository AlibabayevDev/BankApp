using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.Domain.Entities
{
    public class Credit : BaseEntity
    {
        public double Amount { get; set; }
        public double CreditPercent { get; set; }
        public double AmountReturn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime GiveDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int ClientId { get; set; }
        public int BranchId { get; set; }

        public Client Client { get; set; }
        public Branch Branch { get; set; }

        public User Creator { get; set; }
    }
}
