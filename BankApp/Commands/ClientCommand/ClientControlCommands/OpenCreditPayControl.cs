using BankApp.AdminPanel.DataContext;
using BankApp.AdminPanel.ViewModel.Controls.ClientControls;
using BankApp.AdminPanel.Views.Controls.ClientsControls;
using BankApp.AdminPanel.Views.Controls.ClientsControls.ClientCredit;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.ClientCommand.ClientControlCommands
{
    public class OpenCreditPayControl : BaseCommand
    {
        private readonly ClientCreditViewModel viewModel;

        public OpenCreditPayControl(ClientCreditViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            viewModel.CenterGrid.Children.Clear();

            CreditPayViewModel payCreditViewModel = new CreditPayViewModel(Kernel.DB);

            PayControl payControl = new PayControl();

            payCreditViewModel.AllValues = viewModel.DataProvider.GetClient();
            payCreditViewModel.CurrentValue = viewModel.CurrentValue;

            payCreditViewModel.Initialize();





            payControl.DataContext = payCreditViewModel;
            viewModel.CenterGrid.Children.Add(payControl);
        }
    }
}
