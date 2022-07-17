using BankApp.AdminPanel.Mappers;
using BankApp.AdminPanel.Utils;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.AdminPanel.ViewModel.Controls.ClietnControls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.ClientCommand.Commands
{
    public class DeleteCommand : BaseCommand
    {
        private readonly MainClientControlViewModel viewModel;
        public DeleteCommand(MainClientControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if(CommonFunctions.MakeDeleteSure()==false)
                return;

            var currentClient = viewModel.DB.ClientRepository.Get((viewModel.CurrentValue.Id));
            currentClient.IsDeleted = true;

            viewModel.DB.ClientRepository.Update(currentClient);

            viewModel.Message = Constants.OperationSuccessMessage;

            DoAnimation(viewModel.ErrorDialog);

            viewModel.AllValues = viewModel.DataProvider.GetClient();

            viewModel.Initialize();

            viewModel.CurrentValue = null;
            viewModel.CurrentValue = new Model.ClientModel();
        }
    }
}
