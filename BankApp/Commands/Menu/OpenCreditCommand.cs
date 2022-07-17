using BankApp.AdminPanel.DataContext;
using BankApp.AdminPanel.ViewModel;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.AdminPanel.Views.Controls;
using BankApp.AdminPanel.Views.Controls.ClientsControls;
using BankApp.Commands;
using BankApp.Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.Menu
{
    public class OpenCreditCommand : BaseCommand
    {
        private readonly MenuViewModel viewModel;
        public OpenCreditCommand(MenuViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            viewModel.CenterGrid.Children.Clear();

            CreditControlViewModel creditControlViewModel = new CreditControlViewModel(Kernel.DB);

            creditControlViewModel.AllValues = viewModel.DataProvider.GetCredits();
            creditControlViewModel.Clients = viewModel.DataProvider.GetClient();
            creditControlViewModel.Branches = viewModel.DataProvider.GetBranch();
            creditControlViewModel.Initialize();

            CreditControl creditControl = new CreditControl();

            creditControlViewModel.ErrorDialog = creditControl.ErrorDialog;

            creditControl.DataContext = creditControlViewModel;
            viewModel.CenterGrid.Children.Add(creditControl);
        }
    }
}
