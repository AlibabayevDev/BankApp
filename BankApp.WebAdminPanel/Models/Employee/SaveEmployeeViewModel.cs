using BankApp.WebCore.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankApp.WebAdminPanel.Models.Employee
{
    public class SaveEmployeeViewModel
    {
        public SelectList BranchList { get; set; }
        public EmployeeModel Employee { get; set; }
    }
}
