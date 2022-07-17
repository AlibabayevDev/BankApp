using BankApp.AdminPanel.DataContext;
using BankApp.AdminPanel.Model;
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
    public class OpenCardCommand : BaseCommand
    {
        private readonly MenuViewModel viewModel;
        public OpenCardCommand(MenuViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            viewModel.CenterGrid.Children.Clear();

            CardControlViewModel cardControlViewModel = new CardControlViewModel(Kernel.DB);


            cardControlViewModel.AllValues = viewModel.DataProvider.GetCards();
            cardControlViewModel.Clients = viewModel.DataProvider.GetClient();
            cardControlViewModel.Initialize();

            CardControl cardControl = new CardControl();

            cardControlViewModel.ErrorDialog = cardControl.ErrorDialog;

            cardControl.DataContext = cardControlViewModel; 
            viewModel.CenterGrid.Children.Add(cardControl);
        }
    }
}
