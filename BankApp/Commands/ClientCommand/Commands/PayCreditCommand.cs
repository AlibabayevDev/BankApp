using BankApp.AdminPanel.ViewModel.Controls.ClientControls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.ClientCommand.Commands
{
    public class PayCreditCommand : BaseCommand
    {
        private readonly CreditPayViewModel viewModel;

        public PayCreditCommand(CreditPayViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            var Client = viewModel.DB.ClientRepository.GetCredit(viewModel.CurrentValue.Credit.Id);
            var Branch = viewModel.DB.BranchesRepository.Get(Client.Credit.BranchId);

            Client.Credit.Client = Client;
            Client.Credit.Branch = Branch;

            Client.Credit.Amount -= viewModel.PayAmount;

            viewModel.DB.CreditRepository.Update(Client.Credit);
        }
    }
}
