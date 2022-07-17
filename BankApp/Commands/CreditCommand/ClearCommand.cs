using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.CreditCommand
{
    public class ClearCommand : BaseCommand
    {
        private readonly CreditControlViewModel viewModel;

        public ClearCommand(CreditControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }


        public override void Execute(object parameter)
        {
           
        }
    }
}
