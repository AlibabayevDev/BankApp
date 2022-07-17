using BankApp.AdminPanel.DataContext;
using BankApp.AdminPanel.Utils;
using BankApp.AdminPanel.ViewModel;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.AdminPanel.Views.Controls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.Menu
{
    public class OpenEmployeeCommand : BaseCommand
    {
        private readonly MenuViewModel viewModel;

        public OpenEmployeeCommand(MenuViewModel viewModel)
        {
            this.viewModel = viewModel; 
        }

        public override void Execute(object parameter)
        {
            Logger.Log(new Exception());
            viewModel.CenterGrid.Children.Clear();

            EmployeeControlViewModel employeeControlViewModel = new EmployeeControlViewModel(Kernel.DB);

            employeeControlViewModel.AllValues = viewModel.DataProvider.GetEmployee();
            employeeControlViewModel.Branches = viewModel.DataProvider.GetBranch();
            employeeControlViewModel.Initialize();

            EmployeeControl exchangeControl = new EmployeeControl();
            employeeControlViewModel.CenterGrid = exchangeControl.grdCenter;
            employeeControlViewModel.ErrorDialog = exchangeControl.ErrorDialog;

            exchangeControl.DataContext = employeeControlViewModel;
            viewModel.CenterGrid.Children.Add(exchangeControl);
        }
    }
}
