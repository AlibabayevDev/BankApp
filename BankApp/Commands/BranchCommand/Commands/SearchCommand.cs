using BankApp.AdminPanel.Enums;
using BankApp.AdminPanel.Model;
using BankApp.AdminPanel.ViewModel;
using BankApp.AdminPanel.ViewModel.Controls;
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
    public class SearchCommand : BaseCommand
    {
        public readonly BranchControlViewModel viewModel;

        public SearchCommand(BranchControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            OnSearch();
            viewModel.SearchTextName = null;

        }
        public void OnSearch()
        {
            var models = viewModel.AllValues.Where(x => IsCompatibleWithFilterName(x.BranchName));
            viewModel.Values = new ObservableCollection<BranchModel>(models);
        }

        protected bool IsCompatibleWithFilterName(string value)
        {
            if (viewModel.SearchTextName != null)
            {
                if (value != null && value.ToLower().Contains(viewModel.SearchTextName.ToLower()))
                    return true;
            }
            return false;
        }
           

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
