using BankApp.AdminPanel.Enums;
using BankApp.AdminPanel.Model;
using BankApp.AdminPanel.ViewModel;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.AdminPanel.Views.SearchWindows;
using BankApp.AdminPanel.Views.Windows;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.CardCommand
{
    public class OpenSearchCard : BaseCommand
    {
        private readonly CardControlViewModel viewModel;

        public OpenSearchCard(CardControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            SearchWindowCard searchWindow = new SearchWindowCard();
            searchWindow.DataContext = viewModel;
            searchWindow.ShowDialog();

        }
    }
}
