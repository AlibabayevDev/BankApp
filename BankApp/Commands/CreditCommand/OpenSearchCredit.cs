using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.AdminPanel.Views.SearchWindows;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.CreditCommand
{
    public class OpenSearchCredit : BaseCommand
    {
        private readonly CreditControlViewModel viewModel;

        public OpenSearchCredit(CreditControlViewModel viewModel) 
        { 
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            SearchCreditWindow search = new SearchCreditWindow();
            search.DataContext = viewModel;
            search.ShowDialog();
        }
    }
}
