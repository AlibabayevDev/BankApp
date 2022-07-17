using BankApp.AdminPanel.Model;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.CreditCommand
{
    public class ShowAllCreditsCommand : BaseCommand
    {
        private readonly CreditControlViewModel viewModel;

        public ShowAllCreditsCommand(CreditControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            var credits = viewModel.AllValues;
            viewModel.Values = new ObservableCollection<CreditModel>(credits);
        }
    }
}
