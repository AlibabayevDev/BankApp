using BankApp.AdminPanel.Model;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.AdminPanel.ViewModel.Controls.ClientControls;
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
    public class RestoreShowAllClients : BaseCommand
    {
        private readonly RestoreClientControlViewModel viewModel;

        public RestoreShowAllClients(RestoreClientControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            var models = viewModel.Restore;
            viewModel.RestoreValues = new ObservableCollection<ClientModel>(models);
        }

    }
}
