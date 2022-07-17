using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.Domain.Entities
{
    public class Client : BaseEntity
    {
        public Card Card { get; set; }
        public Credit Credit { get; set; }
        public int CardId { get; set; }
        public int CreditId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string FIN { get; set; }
        public string Seriya { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public int AccountNumber { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Citizenship { get; set; }
        public string Studies { get; set; }
        public string Email { get; set; }
        public DateTime PassportEndTime { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime AccountingTime { get; set; }
        public DateTime PassportSubmissionTime {get;set;}
        public bool IsDeleted { get; set; }
    }
}
