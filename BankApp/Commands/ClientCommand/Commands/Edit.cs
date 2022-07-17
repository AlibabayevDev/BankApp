using BankApp.AdminPanel.Enums;
using BankApp.AdminPanel.ViewModel.Controls.ClietnControls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.ClientCommand.Commands
{
    public class Edit : BaseCommand
    {
        public readonly MainClientControlViewModel viewModel;

        public Edit(MainClientControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            viewModel.CurrentSituation = (byte)ClientSituation.EDIT;
        }
    }
}
