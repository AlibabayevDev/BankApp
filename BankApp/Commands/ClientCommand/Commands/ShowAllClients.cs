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

namespace BankApp.AdminPanel.Commands.ClientCommand
{
    public class ShowAllClients : BaseCommand
    {
        private readonly ClientControlViewModel viewModel;

        public ShowAllClients(ClientControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            var models = viewModel.AllValues;
            viewModel.Values = new ObservableCollection<ClientModel>(models);
        }

    }
}
