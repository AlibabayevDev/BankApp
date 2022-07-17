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
    public class CopyFIN : BaseCommand
    {
        private readonly ClientControlViewModel viewModel;

        public CopyFIN(ClientControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            Clipboard.SetText(viewModel.CurrentValue.FIN);
        }
    }
}
