using BankApp.AdminPanel.Model;
using BankApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Mappers
{
    public class EmployeeMapper : BaseMapper<Employee, EmployeeModel>
    {
        private readonly BranchMapper branchMapper = new BranchMapper();

        public override Employee Map(EmployeeModel model)
        {
            return new Employee()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                Branch = branchMapper.Map(model.Branch),
                Surname = model.Surname,
                Speciality = model.Speciality,
                Salary = model.Salary,
                Address = model.Address,
                Phone = model.Phone,
            };
        }

        public override EmployeeModel Map(Employee entity)
        {
            return new EmployeeModel()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                Branch = branchMapper.Map(entity.Branch),
                Surname = entity.Surname,
                Speciality = entity.Speciality,
                Salary = entity.Salary,
                Address = entity.Address,
                Phone = entity.Phone,
            };
        }
    }
}
