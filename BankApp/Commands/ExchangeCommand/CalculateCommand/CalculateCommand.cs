using BankApp.AdminPanel.Model;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.ExchangeCommand.CalculateCommand
{
    public class CalculateCommand : BaseCommand
    {
        private readonly ExchangeControlViewModel viewModel;

        public CalculateCommand(ExchangeControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            ExchangeModel model = new ExchangeModel();

            var amountFromExchange = viewModel.CurrentValue.AmountFromExchange;
            var exchangeRate = viewModel.CurrentValue.ExchangeRate;

            if (exchangeRate != null && amountFromExchange != null)
            {
                var result = exchangeRate * amountFromExchange;

                viewModel.CurrentValue.AmountToExchange = result;
            }
        }
    }
}
