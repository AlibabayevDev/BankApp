using BankApp.AdminPanel.DataContext;
using BankApp.AdminPanel.Utils;
using BankApp.AdminPanel.ViewModel;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.AdminPanel.Views.Controls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.Menu
{
    public class OpenBranchCommand : BaseCommand
    {
        private readonly MenuViewModel viewModel;
        public OpenBranchCommand(MenuViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            Logger.Log(new Exception());
            viewModel.CenterGrid.Children.Clear();

            BranchControlViewModel branchControlViewModel = new BranchControlViewModel(Kernel.DB);

            branchControlViewModel.AllValues = viewModel.DataProvider.GetBranch();
            branchControlViewModel.Initialize();

            BranchControl branchControl = new BranchControl();
            branchControlViewModel.ErrorDialog = branchControl.ErrorDialog;

            branchControl.DataContext = branchControlViewModel;
            viewModel.CenterGrid.Children.Add(branchControl);
        }
    }
}
