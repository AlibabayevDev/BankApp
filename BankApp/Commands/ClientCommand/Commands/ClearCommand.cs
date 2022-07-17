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
    public class ClearCommand : BaseCommand
    {
        public readonly ClientControlViewModel viewModel;
        public ClearCommand(ClientControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            viewModel.SearchTextName = null;
            viewModel.SearchTextSurname = null;
            viewModel.SearchTextFatherName = null;
            viewModel.SearchTextSeriya = null;
            viewModel.SearchTextFIN = null;
            viewModel.SearchTextPhone = null;
        }
    }
}
