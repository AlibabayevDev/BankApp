using BankApp.AdminPanel.DataContext;
using BankApp.AdminPanel.Utils;
using BankApp.AdminPanel.ViewModel;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.AdminPanel.Views.Controls;
using BankApp.AdminPanel.Views.SearchWindows;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.ExchangeCommand
{
    public class OpenSearchExchange : BaseCommand
    {
        private readonly ExchangeControlViewModel viewModel;
        public OpenSearchExchange(ExchangeControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            SearchWindowExchange searchWindow = new SearchWindowExchange();
            searchWindow.DataContext = viewModel;
            searchWindow.ShowDialog();
        }
    }
}
