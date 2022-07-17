using BankApp.AdminPanel.Mappers;
using BankApp.AdminPanel.Utils;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.CardCommand
{
    public class DeleteCardCommand : BaseCommand
    {
        private readonly CardControlViewModel viewModel;

        public DeleteCardCommand(CardControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (CommonFunctions.MakeDeleteSure() == false)
                return;

            CardMapper mapper = new CardMapper();

            var currentCard = viewModel.DB.CardRepository.Get(viewModel.CurrentValue.Id);

            currentCard.IsDeleted = true;

            viewModel.DB.CardRepository.Update(currentCard);


            viewModel.Message = Constants.OperationSuccessMessage;
            DoAnimation(viewModel.ErrorDialog);

            viewModel.AllValues = viewModel.DataProvider.GetCards();
            viewModel.Initialize();
        }


    }
}
