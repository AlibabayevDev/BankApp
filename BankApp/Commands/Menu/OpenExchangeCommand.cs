using BankApp.AdminPanel.DataContext;
using BankApp.AdminPanel.Model;
using BankApp.AdminPanel.Utils;
using BankApp.AdminPanel.ViewModel;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.AdminPanel.Views.Controls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.Menu
{
    public class OpenExchangeCommand : BaseCommand
    {
        private readonly MenuViewModel viewModel;
        public OpenExchangeCommand(MenuViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            Logger.Log(new Exception());
            viewModel.CenterGrid.Children.Clear();

            ExchangeControlViewModel exchangeControlViewModel = new ExchangeControlViewModel(Kernel.DB);

            exchangeControlViewModel.AllValues = viewModel.DataProvider.GetExchange();
            exchangeControlViewModel.Clients = viewModel.DataProvider.GetClient();
            exchangeControlViewModel.Initialize();

            ExchangeControl exchangeControl = new ExchangeControl();

            exchangeControlViewModel.CenterGrid = exchangeControl.grdCenter;
            exchangeControlViewModel.ErrorDialog = exchangeControl.ErrorDialog;

            exchangeControl.DataContext = exchangeControlViewModel;
            viewModel.CenterGrid.Children.Add(exchangeControl);
        }
    }
}
