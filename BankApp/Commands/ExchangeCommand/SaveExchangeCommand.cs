using BankApp.AdminPanel.Enums;
using BankApp.AdminPanel.Mappers;
using BankApp.AdminPanel.Model;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.ExchangeCommand.Commands
{
    public class SaveExchangeCommand : BaseCommand
    {
        private readonly ExchangeControlViewModel viewModel;
        public SaveExchangeCommand(ExchangeControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            switch (viewModel.CurrentSituation)
            {
                case (int)Situations.NORMAL:
                    viewModel.CurrentSituation = (int)Situations.ADD;
                    break;
                case (int)Situations.SELECTED:
                    viewModel.CurrentSituation = (int)Situations.EDIT;
                    break;
                case (int)Situations.ADD:
                case (int)Situations.EDIT:
                    Save();
                    break;
            }
        }

        private void Save()
        {
            viewModel.CurrentValue.Client = viewModel.SelectedClient;

            if (viewModel.CurrentValue.IsValid(out string message) == false)
            {
                viewModel.Message = message;
                DoAnimation(viewModel.ErrorDialog);
                return;
            }

            ExchangeMapper exchangeMapper = new ExchangeMapper();

            viewModel.CurrentValue.Client = viewModel.SelectedClient;

            var exchange = exchangeMapper.Map(viewModel.CurrentValue);

            if (exchange.Id != 0)
            {
                viewModel.DB.ExchangeRepository.Update(exchange);
            }
            else
            {
                viewModel.DB.ExchangeRepository.Insert(exchange);

            }

            viewModel.Message = Constants.OperationSuccessMessage;
            DoAnimation(viewModel.ErrorDialog);

            viewModel.CurrentValue = null;
            viewModel.CurrentValue = new ExchangeModel();
            viewModel.SelectedClient = null;

            viewModel.AllValues = viewModel.DataProvider.GetExchange();
            viewModel.Initialize();
        }
    }
}
