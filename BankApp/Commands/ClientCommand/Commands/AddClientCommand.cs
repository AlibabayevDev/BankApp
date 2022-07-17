using BankApp.AdminPanel.Commands.ClientCommand.ClientControlCommands;
using BankApp.AdminPanel.Enums;
using BankApp.AdminPanel.Model;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.AdminPanel.ViewModel.Controls.ClietnControls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.ClientCommand
{
    public class AddClientCommand : BaseCommand
    {
        public readonly ClientControlViewModel viewModel;
        public AddClientCommand(ClientControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            viewModel.CurrentValue = null;
            viewModel.CurrentValue=new ClientModel();

            OpenMainControlClient open=new OpenMainControlClient(viewModel);
            viewModel.CurrentSituation = (int)ClientSituation.NORMAL;
            open.Open();
        }
    }
}
