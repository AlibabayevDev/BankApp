using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankApp.AdminPanel.Commands.ClientCommand.Commands
{
    public class CopySeriya : BaseCommand
    {
        private readonly ClientControlViewModel viewModel;

        public CopySeriya(ClientControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if(viewModel.CurrentValue.Seriya != null)
            {
                Clipboard.SetText(viewModel.CurrentValue.Seriya);
            }
        }
    }
}
