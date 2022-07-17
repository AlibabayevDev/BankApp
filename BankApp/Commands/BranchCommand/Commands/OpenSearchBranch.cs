using BankApp.AdminPanel.Enums;
using BankApp.AdminPanel.Model;
using BankApp.AdminPanel.ViewModel;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.AdminPanel.Views.Controls;
using BankApp.AdminPanel.Views.SearchWindows;
using BankApp.AdminPanel.Views.Windows;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.BranchCommand
{
    public class OpenSearchBranch : BaseCommand
    {
        private readonly BranchControlViewModel viewModel;

        public OpenSearchBranch(BranchControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {            
            SearchWindowBranch searchWindow = new SearchWindowBranch();
            searchWindow.DataContext = viewModel;
            searchWindow.ShowDialog();
        }
    }
}
