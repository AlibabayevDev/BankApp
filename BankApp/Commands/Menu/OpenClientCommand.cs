using BankApp.AdminPanel.DataContext;
using BankApp.AdminPanel.Model;
using BankApp.AdminPanel.Utils;
using BankApp.AdminPanel.ViewModel;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.AdminPanel.Views.Controls;
using BankApp.AdminPanel.Views.Windows;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankApp.AdminPanel.Commands.Main
{
    public class OpenClientCommand : BaseCommand
    {
        private readonly MenuViewModel viewModel;
        public OpenClientCommand(MenuViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            Logger.Log(new Exception());
            viewModel.CenterGrid.Children.Clear();

            ClientControlViewModel clientControlViewModel = new ClientControlViewModel(Kernel.DB);

            clientControlViewModel.AllValues = viewModel.DataProvider.GetClient();
            clientControlViewModel.Initialize();

            ClientControl clientControl = new ClientControl();
            clientControlViewModel.CenterGrid = clientControl.grdCenter;
            clientControlViewModel.ErrorDialog=clientControl.ErrorDialog;

            clientControl.DataContext = clientControlViewModel;
            viewModel.CenterGrid.Children.Add(clientControl);
        }
    }
}
