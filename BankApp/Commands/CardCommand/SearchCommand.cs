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

namespace BankApp.AdminPanel.Commands.CardCommand
{
    public class SearchCommand : BaseCommand
    {
        public readonly CardControlViewModel viewModel;

        public SearchCommand(CardControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            OnSearch();
            viewModel.SearchTextName = null;
            viewModel.SearchTextCardNumber = null;
            viewModel.SearchTextTypeCard = null;
            viewModel.SearchTextNo = null;
        }

        public void OnSearch()
        {
            var models = viewModel.AllValues.Where(x => IsCompatibleWithFilterNo(x.NO) || IsCompatibleWithFilterName(x.Client.Name)  || IsCompatibleWithFilterCardNumber(x.CardNumber) || IsCompatibleWithFilterTypeCard(x.TypeCard));
            viewModel.Values = new ObservableCollection<CardModel>(models);
        }

        protected bool IsCompatibleWithFilterNo(int value)
        {
            if (viewModel.SearchTextNo!= null)
            {
                string Value=Convert.ToString(value);
                if (Value != null && Value.ToLower().Contains(viewModel.SearchTextNo.ToLower()))
                    return true;
            }
            return false;
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


        protected bool IsCompatibleWithFilterCardNumber(string value)
        {
            if (viewModel.SearchTextCardNumber != null)
            {
                if (value != null && value.ToLower().Contains(viewModel.SearchTextCardNumber.ToLower()))
                    return true;
            }
            return false;
        }

        protected bool IsCompatibleWithFilterTypeCard(string value)
        {
            if (viewModel.SearchTextTypeCard != null)
            {
                if (value != null && value.ToLower().Contains(viewModel.SearchTextTypeCard.ToLower()))
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
