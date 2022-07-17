using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.Domain.Entities
{
    public class Card : BaseEntity
    {
        public int ClientId { get; set; }
        public string TypeCard { get; set; }
        public string CardNumber { get; set; }
        public DateTime EndDate { get; set; } 
        public bool IsDeleted { get; set; } 

        public Client Client { get; set; }
    }
}
