using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.Domain.Entities
{
    public class Rate: BaseEntity
    {
        public string AmountFromExchange { get; set; }
        public string AmountToExchange { get; set; }
        public double Currency { get; set; }
    }
}
