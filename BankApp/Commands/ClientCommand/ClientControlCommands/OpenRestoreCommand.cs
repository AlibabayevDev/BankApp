using BankApp.AdminPanel.DataContext;
using BankApp.AdminPanel.Utils;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.AdminPanel.ViewModel.Controls.ClientControls;
using BankApp.AdminPanel.ViewModel.Controls.ClietnControls;
using BankApp.AdminPanel.Views.Controls.ClientsControls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.ClientCommand.Commands
{
    public class OpenRestoreCommand : BaseCommand
    {
        private readonly MainClientControlViewModel viewModel;
        public OpenRestoreCommand(MainClientControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            viewModel.CenterGridMainClient.Children.Clear();

            RestoreClientControlViewModel clientControlViewModel = new RestoreClientControlViewModel(Kernel.DB);

            clientControlViewModel.Restore = viewModel.DataProvider.RestoreClient();
            clientControlViewModel.Inizialize();

            RestoreClientsControl restoreClients = new RestoreClientsControl();
            clientControlViewModel.ErrorDialog = restoreClients.ErrorDialog;
            clientControlViewModel.CenterGrid = restoreClients.CenterGrid;


            restoreClients.DataContext = clientControlViewModel;
            viewModel.CenterGridMainClient.Children.Add(restoreClients);
        }
    }
}
