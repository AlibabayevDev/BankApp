using BankApp.AdminPanel.DataContext;
using BankApp.AdminPanel.Utils;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.AdminPanel.ViewModel.Controls.ClietnControls;
using BankApp.AdminPanel.Views.Controls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankApp.AdminPanel.Commands.ClientCommand.ClientControlCommands
{
    public class OpenClientControl : BaseCommand
    {
        private readonly MainClientControlViewModel viewModel;
        public OpenClientControl(MainClientControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            viewModel.CenterGridMainClient.Children.Clear();

            ClientControlViewModel clientControlViewModel = new ClientControlViewModel(Kernel.DB);

            clientControlViewModel.AllValues = viewModel.DataProvider.GetClient();
            clientControlViewModel.Initialize();

            ClientControl clientControl = new ClientControl();
            clientControlViewModel.CenterGrid = clientControl.grdCenter;
            clientControlViewModel.ErrorDialog = clientControl.ErrorDialog;


            clientControl.DataContext = clientControlViewModel;
            viewModel.CenterGridMainClient.Children.Add(clientControl);
        }
    }
}
