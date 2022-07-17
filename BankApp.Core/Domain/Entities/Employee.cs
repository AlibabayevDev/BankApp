using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.Domain.Entities
{
    public class Employee : BaseEntity
    {
       // public int IdLogin { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Speciality { get; set; }
        public int BranchId { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool IsDeleted { get; set; }

        public Branch Branch { get; set; }
    }
}
