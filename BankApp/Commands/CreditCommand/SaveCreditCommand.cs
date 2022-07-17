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

namespace BankApp.AdminPanel.Commands.CreditCommand
{
    public class SaveCreditCommand : BaseCommand
    {
        private readonly CreditControlViewModel? viewModel;

        public SaveCreditCommand(CreditControlViewModel viewModel)
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
            viewModel.CurrentValue.Branch = viewModel.SelectedBranch;

            if (viewModel.CurrentValue.IsValid(out string message) == false)
            {
                viewModel.Message = message;
                DoAnimation(viewModel.ErrorDialog);
                return;
            }

            //

            CreditMapper creditMapper = new CreditMapper();

            viewModel.CurrentValue.Client = viewModel.SelectedClient;
            viewModel.CurrentValue.Branch = viewModel.SelectedBranch;

            var creditEntity = creditMapper.Map(viewModel.CurrentValue);


            if (creditEntity.Id != 0)
            {
                viewModel.DB.CreditRepository.Update(creditEntity);
            }
            else
            {
                viewModel.DB.CreditRepository.Insert(creditEntity);
            }

            viewModel.Message = Constants.OperationSuccessMessage;

            DoAnimation(viewModel.ErrorDialog);

            viewModel.CurrentValue = null;
            viewModel.CurrentValue = new CreditModel();
            viewModel.SelectedBranch = null;
            viewModel.SelectedClient = null;

            viewModel.AllValues = viewModel.DataProvider.GetCredits();
            viewModel.Initialize();

        }
    }
}
