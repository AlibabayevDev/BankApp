using BankApp.WebAdminPanel.Models;
using BankApp.WebAzBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.WebCore.Model
{
    public class EmployeeModel : BaseModel
    {
        public BranchModel Branch { get; set; } = new BranchModel();

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string Speciality { get; set; }

        public decimal Salary { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

    }
}
