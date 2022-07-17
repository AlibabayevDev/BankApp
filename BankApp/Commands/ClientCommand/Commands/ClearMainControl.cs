using BankApp.AdminPanel.Enums;
using BankApp.AdminPanel.Model;
using BankApp.AdminPanel.ViewModel.Controls.ClietnControls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.ClientCommand.Commands
{
    public class ClearMainControl : BaseCommand
    {
        private readonly MainClientControlViewModel viewModel;
        public ClearMainControl(MainClientControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            viewModel.CurrentValue = null;
            viewModel.CurrentSituation = (byte)Situations.ADD;
            viewModel.CurrentValue = new ClientModel();
        }
    }
}
