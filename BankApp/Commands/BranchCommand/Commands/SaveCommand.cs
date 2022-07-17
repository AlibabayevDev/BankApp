using BankApp.AdminPanel.Enums;
using BankApp.AdminPanel.Mappers;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.AdminPanel.Views.Windows;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankApp.AdminPanel.Commands.BranchCommand
{
    public class SaveCommand : BaseCommand
    {
        private readonly BranchControlViewModel viewModel;
        public SaveCommand(BranchControlViewModel viewModel)
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
            if(viewModel.CurrentValue.IsValid(out string message) == false)
            {
                viewModel.Message = message;
                DoAnimation(viewModel.ErrorDialog);
                return;
            }

            BranchMapper branchMapper = new BranchMapper();

            var bank = branchMapper.Map(viewModel.CurrentValue);


            if (bank.Id != 0)
            {
                viewModel.DB.BranchesRepository.Update(bank);
            }
            else
            {
                viewModel.DB.BranchesRepository.Insert(bank);
            }

            viewModel.Message = Constants.OperationSuccessMessage;

            DoAnimation(viewModel.ErrorDialog);

            viewModel.AllValues = viewModel.DataProvider.GetBranch();

            viewModel.Initialize();
        }
    }
}
