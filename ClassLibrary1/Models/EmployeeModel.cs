using BankApp.WebCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [StringLength(13, MinimumLength = 13,ErrorMessage ="Number must have 13 symbol")]
        public string Phone { get; set; }

    }
}
