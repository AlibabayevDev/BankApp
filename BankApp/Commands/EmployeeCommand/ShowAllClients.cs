using BankApp.AdminPanel.Model;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.EmployeeCommand
{
    public class ShowAllClients : BaseCommand
    {
        private readonly EmployeeControlViewModel viewModel;

        public ShowAllClients(EmployeeControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            var models = viewModel.AllValues;
            viewModel.Values = new ObservableCollection<EmployeeModel>(models);
        }

    }
}
