using BankApp.AdminPanel.Commands.ChangePasswordCommand;
using BankApp.AdminPanel.ViewModels;
using BankApp.AdminPanel.Views.Email;
using BankApp.Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankApp.AdminPanel.ViewModel.Email
{
    public class ForgotPasswordViewModel : BaseWindowViewModel
    {
        public readonly ForgotPasswordWindow forgotPasswordWindow;

        public ForgotPasswordViewModel(IUnitOfWork db, ForgotPasswordWindow forgotPasswordWindow) : base(db, forgotPasswordWindow)
        {
            this.forgotPasswordWindow = forgotPasswordWindow;
        }


        public string Username { get; set; } = "nahidmirzazada@gmail.com";

        public ForgotPasswordCommand Send => new ForgotPasswordCommand(this);




        private Visibility errorMailMessage = Visibility.Collapsed;
        public Visibility ErrorMailMessage
        {
            get
            {
                return errorMailMessage;
            }
            set
            {
                errorMailMessage = value;
                OnPropertyChanged(nameof(ErrorMailMessage));
            }
        }

        private Visibility successMessage = Visibility.Collapsed;
        public Visibility SuccessMessage
        {
            get
            {
                return successMessage;
            }
            set
            {
                successMessage = value;
                OnPropertyChanged(nameof(SuccessMessage));
            }
        }

    }
}
