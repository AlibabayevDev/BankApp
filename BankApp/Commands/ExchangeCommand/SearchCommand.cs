using BankApp.AdminPanel.Model;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.ExchangeCommand
{
    public class SearchCommand : BaseCommand
    {
        public readonly ExchangeControlViewModel viewModel;

        public SearchCommand(ExchangeControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            OnSearch();
            viewModel.SearchTextName = null;
            viewModel.SearchTextPhone = null;
        }

        public void OnSearch()
        {
            var models = viewModel.AllValues.Where(x => IsCompatibleWithFilterName(x.Client.Name) || IsCompatibleWithFilterPhone(x.Phone));
            viewModel.Values = new ObservableCollection<ExchangeModel>(models);
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

        protected bool IsCompatibleWithFilterPhone(string value)
        {
            if (viewModel.SearchTextPhone != null)
            {
                if (value != null && value.ToLower().Contains(viewModel.SearchTextPhone.ToLower()))
                    return true;
            }
            return false;
        }
    }
}
