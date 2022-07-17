using BankApp.AdminPanel.DataContext;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.AdminPanel.Views.Controls.ExchangeControls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.ExchangeCommand.CalculateCommand
{
    public class OpenCalculateCommand : BaseCommand
    {
        private readonly ExchangeControlViewModel viewModel;
        public OpenCalculateCommand(ExchangeControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            CalculateWindow calculateWindow = new CalculateWindow();
            calculateWindow.DataContext = viewModel;
            calculateWindow.ShowDialog();
        }
    }
}
