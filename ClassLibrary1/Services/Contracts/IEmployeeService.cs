using BankApp.WebCore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.WebCore.Services.Contracts
{
    public interface IEmployeeService
    {
        List<EmployeeModel> GetAll();
    }
}
