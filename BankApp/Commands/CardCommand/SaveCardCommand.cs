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

namespace BankApp.AdminPanel.Commands.CardCommand
{
    public class SaveCardCommand : BaseCommand
    {
        private readonly CardControlViewModel? viewModel;

        public SaveCardCommand(CardControlViewModel viewModel)
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
                    {
                        Save();
                        break;
                    }
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

            CardMapper cardMapper = new CardMapper();

            viewModel.CurrentValue.Client = viewModel.SelectedClient;

            var cardEntity = cardMapper.Map(viewModel.CurrentValue);

            // cardEntity.CreatorId = Kernel.CurrentUser.Id;

            if (cardEntity.Id != 0)
            {
                viewModel.DB.CardRepository.Update(cardEntity);
            }
            else
            {
                viewModel.DB.CardRepository.Insert(cardEntity);
            }

            viewModel.Message = Constants.OperationSuccessMessage;

            DoAnimation(viewModel.ErrorDialog);

            viewModel.CurrentValue = null;
            viewModel.CurrentValue = new CardModel();
            viewModel.SelectedClient = null;

            viewModel.AllValues = viewModel.DataProvider.GetCards();
            viewModel.Initialize();


        }
    }
}
