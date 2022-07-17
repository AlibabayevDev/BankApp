using BankApp.AdminPanel.Utils;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.EmployeeCommand
{
    public class DeleteCommand : BaseCommand
    {
        private readonly EmployeeControlViewModel viewModel;

        public DeleteCommand(EmployeeControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (CommonFunctions.MakeDeleteSure() == false)
                return;

            var currentEmployee = viewModel.DB.EmployeeRepository.Get((viewModel.CurrentValue.Id));
            currentEmployee.IsDeleted = true;

            viewModel.DB.EmployeeRepository.Update(currentEmployee);

            viewModel.Message = Constants.OperationSuccessMessage;

            DoAnimation(viewModel.ErrorDialog);

            viewModel.AllValues = viewModel.DataProvider.GetEmployee();

            viewModel.Initialize();
        }
    }
}
