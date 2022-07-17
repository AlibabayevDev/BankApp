using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.AdminPanel.Views.SearchWindows;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.EmployeeCommand
{
    public class OpenSearchEmployee : BaseCommand
    {
        private readonly EmployeeControlViewModel viewModel;
        public OpenSearchEmployee(EmployeeControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            SearchWindowEmployee searchWindow = new SearchWindowEmployee();
            searchWindow.DataContext = viewModel;
            searchWindow.ShowDialog();
        }
    }
}
