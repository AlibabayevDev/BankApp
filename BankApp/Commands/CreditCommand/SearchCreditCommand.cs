using BankApp.AdminPanel.Model;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.CreditCommand
{
    public class SearchCreditCommand : BaseCommand
    {
        private readonly CreditControlViewModel viewModel;

        public SearchCreditCommand(CreditControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            OnSearch();
            viewModel.SearchTextAmount = null;
            viewModel.SearchTextClient = null;
            viewModel.SearchtextBranch = null; 
        }

        public void OnSearch()
        {
            var models = viewModel.AllValues.Where(x => IsCompatibleWithFilterAmount(x.Amount.ToString()) || IsCompatibleWithFilterClient(x.Client.Name)  || IsCompatibleWithFilterBranch(x.Branch.BranchName));
            viewModel.Values = new ObservableCollection<CreditModel>(models);
        }


        protected bool IsCompatibleWithFilterAmount(string value)
        {
            if (viewModel.SearchTextAmount != null)
            {
                if (value != null && value.ToLower().Contains(viewModel.SearchTextAmount.ToLower()))
                    return true;
            }
            return false;
        }


        protected bool IsCompatibleWithFilterClient(string value)
        {
            if (viewModel.SearchTextClient != null)
            {
                if (value != null && value.ToLower().Contains(viewModel.SearchTextClient.ToLower()))
                    return true;
            }
            return false;
        }

        protected bool IsCompatibleWithFilterBranch(string value)
        {
            if (viewModel.SearchtextBranch != null)
            {
                if (value != null && value.ToLower().Contains(viewModel.SearchtextBranch.ToLower()))
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
