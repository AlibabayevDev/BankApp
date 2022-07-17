using BankApp.AdminPanel.ViewModel;
using BankApp.Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentOrder.AdminPanel.ViewModels.Dialogs
{
    public class SureDialogViewModel : BaseViewModel
    {
        private string _dialogText;

        public string DialogText
        {
            get => _dialogText;
            set
            {
                _dialogText = value;
                OnPropertyChanged(nameof(DialogText));
            }
        }
    }
}
