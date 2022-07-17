using BankApp.AdminPanel.Enums;
using BankApp.AdminPanel.Mappers;
using BankApp.AdminPanel.Model;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.EmployeeCommand
{
    public class SaveEmployeeCommand : BaseCommand
    {
        private readonly EmployeeControlViewModel viewModel;

        public SaveEmployeeCommand(EmployeeControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            switch (viewModel.CurrentSituation)
            {
                case (int)Situations.NORMAL:
                    viewModel.CurrentSituation = (int)Situations.ADD;
                    break;
                case (int)Situations.SELECTED:
                    viewModel.CurrentSituation = (int)Situations.EDIT;
                    break;
                case (int)Situations.ADD:
                case (int)Situations.EDIT:
                    Save();
                    break;
            }
        }

        private void Save()
        {
            viewModel.CurrentValue.Branch = viewModel.SelectedBranch;

            if (viewModel.CurrentValue.IsValid(out string message) == false)
            {
                viewModel.Message = message;
                DoAnimation(viewModel.ErrorDialog);
                return;
            }

            EmployeeMapper employeeMapper = new EmployeeMapper();

            viewModel.CurrentValue.Branch = viewModel.SelectedBranch;

            var employee = employeeMapper.Map(viewModel.CurrentValue);

            if (employee.Id != 0)
            {
                viewModel.DB.EmployeeRepository.Update(employee);
            }
            else
            {
                viewModel.DB.EmployeeRepository.Insert(employee);

            }

            viewModel.Message = Constants.OperationSuccessMessage;
            DoAnimation(viewModel.ErrorDialog);

            viewModel.CurrentValue = null;
            viewModel.CurrentValue = new EmployeeModel();
            viewModel.SelectedBranch = null;

            viewModel.AllValues = viewModel.DataProvider.GetEmployee();
            viewModel.Initialize();
        }
    }
}
