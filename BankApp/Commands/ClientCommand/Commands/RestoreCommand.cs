using BankApp.AdminPanel.Model;
using BankApp.AdminPanel.Utils;
using BankApp.AdminPanel.ViewModel.Controls.ClientControls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.ClientCommand.Commands
{
    public class RestoreCommand : BaseCommand
    {
        private readonly RestoreClientControlViewModel viewModel;
        public RestoreCommand(RestoreClientControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            if (CommonFunctions.MakeRestoreSure() == false)
                return;

            var currentClient = viewModel.DB.ClientRepository.GetRestore((viewModel.CurrentValue.Id));
            currentClient.IsDeleted = false;

            viewModel.DB.ClientRepository.Update(currentClient);

            viewModel.Message = Constants.OperationSuccessMessage;

            DoAnimation(viewModel.ErrorDialog);

            viewModel.Restore = viewModel.DataProvider.RestoreClient();

            viewModel.RestoreValues = new ObservableCollection<ClientModel>(viewModel.Restore);
        }
    }
}
