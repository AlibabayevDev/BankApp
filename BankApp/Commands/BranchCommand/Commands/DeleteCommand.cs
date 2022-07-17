using BankApp.AdminPanel.Mappers;
using BankApp.AdminPanel.Utils;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.BranchCommand
{
    public class DeleteCommand : BaseCommand
    {
        private readonly BranchControlViewModel viewModel;
        public DeleteCommand(BranchControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if(CommonFunctions.MakeDeleteSure()==false)
                return;

            var currentBranch = viewModel.DB.BranchesRepository.Get((viewModel.CurrentValue.Id));
            currentBranch.IsDeleted = true;

            viewModel.DB.BranchesRepository.Update(currentBranch);

            viewModel.Message = Constants.OperationSuccessMessage;

            DoAnimation(viewModel.ErrorDialog);

            viewModel.AllValues = viewModel.DataProvider.GetBranch();

            viewModel.Initialize();
        }
    }
}
