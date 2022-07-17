using BankApp.AdminPanel.Enums;
using BankApp.AdminPanel.Model;
using BankApp.AdminPanel.ViewModel.Controls.ClietnControls;
using BankApp.AdminPanel.Views.Controls.ClientsControls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.ClientCommand.Commands
{
    public class Cancel : BaseCommand
    {
        private readonly MainClientControlViewModel viewModel;
        public Cancel(MainClientControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            if(viewModel.CurrentValue.Id==0)
            {
                viewModel.CurrentValue = new ClientModel();
                viewModel.CurrentSituation = (int)ClientSituation.CANCEL;
                return;
            }
            viewModel.CurrentSituation = (int)ClientSituation.NORMAL;
            viewModel.CardGrid.Children.Clear();
        }
    }
}
