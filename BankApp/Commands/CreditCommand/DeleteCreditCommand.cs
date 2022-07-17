using BankApp.AdminPanel.Mappers;
using BankApp.AdminPanel.Utils;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.CreditCommand
{
    public class DeleteCreditCommand : BaseCommand
    {
        private readonly CreditControlViewModel viewModel;

        public DeleteCreditCommand(CreditControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }


        public override void Execute(object parameter)
        {
            if (CommonFunctions.MakeDeleteSure() == false)
                return;

            CreditMapper mapper = new CreditMapper();

            var currentCredit = viewModel.DB.CreditRepository.Get(viewModel.CurrentValue.Id);

            currentCredit.IsDeleted = true;

            viewModel.DB.CreditRepository.Update(currentCredit);

            viewModel.Message = Constants.OperationSuccessMessage;
            DoAnimation(viewModel.ErrorDialog);

            viewModel.AllValues = viewModel.DataProvider.GetCredits();
            viewModel.Initialize();
        }
    }
}
