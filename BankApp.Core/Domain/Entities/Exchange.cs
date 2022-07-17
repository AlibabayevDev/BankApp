using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.Domain.Entities
{
    public class Exchange : BaseEntity
    {
        public int IdClient { get; set; }
        public string Phone { get; set; }
        public double AmountToExchange { get; set; }
        public double AmountFromExchange { get; set; }
        public string ConvertFromCurrency { get; set; }
        public string ConvertToCurrency { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }

        public Client Client { get; set; }
    }
}
