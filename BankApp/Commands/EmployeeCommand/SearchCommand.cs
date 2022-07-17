using BankApp.AdminPanel.Model;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.EmployeeCommand
{
    public class SearchCommand : BaseCommand
    {
        public readonly EmployeeControlViewModel viewModel;

        public SearchCommand(EmployeeControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            OnSearch();
            viewModel.SearchTextName = null;
            viewModel.SearchTextSurname = null;
            viewModel.SearchTextSpeciality = null;
            viewModel.SearchTextAddress = null;
            viewModel.SearchTextPhone = null;
        }

        public void OnSearch()
        {
            var models = viewModel.AllValues.Where(x => IsCompatibleWithFilterName(x.FirstName) || IsCompatibleWithFilterSurname(x.Surname) || IsCompatibleWithFilterSpeciality(x.Speciality) || IsCompatibleWithFilterAddress(x.Address) || IsCompatibleWithFilterPhone(x.Phone) );
            viewModel.Values = new ObservableCollection<EmployeeModel>(models);
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

        protected bool IsCompatibleWithFilterSpeciality(string value)
        {
            if (viewModel.SearchTextSpeciality != null)
            {
                if (value != null && value.ToLower().Contains(viewModel.SearchTextSpeciality.ToLower()))
                    return true;
            }
            return false;
        }

        protected bool IsCompatibleWithFilterAddress(string value)
        {
            if (viewModel.SearchTextAddress != null)
            {
                if (value != null && value.ToLower().Contains(viewModel.SearchTextAddress.ToLower()))
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
