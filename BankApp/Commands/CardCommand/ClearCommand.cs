using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.CardCommand
{
    public class ClearCommand : BaseCommand
    {
        public readonly CardControlViewModel viewModel;
        public ClearCommand(CardControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            viewModel.SearchTextTypeCard = null;
            viewModel.SearchTextNo = null;
            viewModel.SearchTextName = null;
            viewModel.SearchTextCardNumber = null;
        }
    }
}
