using BankApp.AdminPanel.Enums;
using BankApp.AdminPanel.Model;
using BankApp.AdminPanel.ViewModel;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.AdminPanel.ViewModel.Controls.ClientControls;
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

namespace BankApp.AdminPanel.Commands.ClientCommand
{
    public class RestoreSearchCommand : BaseCommand
    {
        public readonly RestoreClientControlViewModel viewModel;

        public RestoreSearchCommand(RestoreClientControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            OnSearch();
            viewModel.SearchTextName = null;
            viewModel.SearchTextSurname = null;
            viewModel.SearchTextFatherName = null;
            viewModel.SearchTextSeriya = null;
            viewModel.SearchTextFIN = null;
            viewModel.SearchTextPhone = null;
        }
        public void OnSearch()
        {
            var models = viewModel.Restore.Where(x => IsCompatibleWithFilterName(x.Name) || IsCompatibleWithFilterSurname(x.Surname) || IsCompatibleWithFilterFatherName(x.FatherName) || IsCompatibleWithFilterFIN(x.FIN) || IsCompatibleWithFilterSeriya(x.Seriya) || IsCompatibleWithFilterPhone(x.Phone));
            viewModel.RestoreValues = new ObservableCollection<ClientModel>(models);
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
        protected bool IsCompatibleWithFilterSurname(string value)
        {
            if (viewModel.SearchTextSurname != null)
            {
                if (value != null && value.ToLower().Contains(viewModel.SearchTextSurname.ToLower()))
                    return true;
            }
            return false;
        }

        protected bool IsCompatibleWithFilterFatherName(string value)
        {
            if (viewModel.SearchTextFatherName != null)
            {
                if (value != null && value.ToLower().Contains(viewModel.SearchTextFatherName.ToLower()))
                    return true;
            }
            return false;
        }

        protected bool IsCompatibleWithFilterSeriya(string value)
        {
            if (viewModel.SearchTextSeriya != null)
            {
                if (value != null && value.ToLower().Contains(viewModel.SearchTextSeriya.ToLower()))
                    return true;
            }
            return false;
        }

        protected bool IsCompatibleWithFilterFIN(string value)
        {
            if (viewModel.SearchTextFIN != null)
            {
                if (value != null && value.ToLower().Contains(viewModel.SearchTextFIN.ToLower()))
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


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
