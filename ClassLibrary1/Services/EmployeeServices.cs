using BankApp.Core.DataAccess.Abstract;
using BankApp.WebCore.Mappers;
using BankApp.WebCore.Model;
using BankApp.WebCore.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.WebCore.Services
{
    public class EmployeeServices : IEmployeeService
    {

        private readonly IUnitOfWork db;

        public EmployeeServices(IUnitOfWork db)
        {
            this.db = db;
        }
        public List<EmployeeModel> GetAll()
        {
            var employees = db.EmployeeRepository.Get();

            EmployeeMapper employeeBranch = new EmployeeMapper();
            List<EmployeeModel> employeeModels = new List<EmployeeModel>();

            for (int i = 0; i < employees.Count; i++)
            {
                var employee = employees[i];
                var employeeModel = employeeBranch.Map(employee);

                employeeModel.NO = i + 1;
                employeeModels.Add(employeeModel);
            }
            return employeeModels;
        }
    }
}
