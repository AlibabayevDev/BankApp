using BankApp.AdminPanel.Utils;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.ExchangeCommand.Commands
{
    public class DeleteCommand : BaseCommand
    {
        private readonly ExchangeControlViewModel viewModel;
        public DeleteCommand(ExchangeControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (CommonFunctions.MakeDeleteSure() == false)
                return;

            var currentExchange = viewModel.DB.ExchangeRepository.Get((viewModel.CurrentValue.Id));
            currentExchange.IsDeleted = true;

            viewModel.DB.ExchangeRepository.Update(currentExchange);

            viewModel.Message = Constants.OperationSuccessMessage;

            DoAnimation(viewModel.ErrorDialog);

            viewModel.AllValues = viewModel.DataProvider.GetExchange();

            viewModel.Initialize();
        }
    }
}
