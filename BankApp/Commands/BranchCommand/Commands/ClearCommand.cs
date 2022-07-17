using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.BranchCommand
{
    public class ClearCommand : BaseCommand
    {
        public readonly BranchControlViewModel viewModel;
        public ClearCommand(BranchControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            viewModel.SearchTextName = null;
        }
    }
}
