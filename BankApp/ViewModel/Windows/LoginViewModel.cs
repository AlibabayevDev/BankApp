using BankApp.AdminPanel.Commands.Auth;
using BankApp.AdminPanel.Commands.ChangePasswordCommand;
using BankApp.AdminPanel.ViewModel;
using BankApp.AdminPanel.ViewModels;
using BankApp.Commands;
using BankApp.Core.DataAccess.Abstract;
using BankApp.Core.Utils;
using BankApp.Views.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BankApp.ViewModel
{
    public class LoginViewModel : BaseWindowViewModel
    {
        public readonly LoginWindow LoginWindow;

        public LoginViewModel(LoginWindow loginWindow,IUnitOfWork db) : base(db,loginWindow)
        {
            LoginWindow = loginWindow;
        }
        

        public string Username { get; set; } = "nahidmirzazada@gmail.com";


        public LoginCommand SignIn => new LoginCommand(this);
        public ICommand OpenForgotPasswordCommand => new OpenForgotPasswordCommand(this);


        private Visibility loginErrorVisibility = Visibility.Collapsed;
        public Visibility LoginErrorVisibility
        {
            get
            {
                return loginErrorVisibility;
            }
            set
            {
                loginErrorVisibility = value;
                OnPropertyChanged(nameof(LoginErrorVisibility));
            }
        }
    }
}

