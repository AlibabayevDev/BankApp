using BankApp.AdminPanel.Model;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.BranchCommand
{
    public class ShowAllClients : BaseCommand
    {
        private readonly BranchControlViewModel viewModel;

        public ShowAllClients(BranchControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            var models = viewModel.AllValues;
            viewModel.Values = new ObservableCollection<BranchModel>(models);
        }

    }
}
