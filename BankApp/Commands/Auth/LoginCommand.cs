using BankApp.AdminPanel.DataContext;
using BankApp.AdminPanel.Utils;
using BankApp.AdminPanel.ViewModel;
using BankApp.AdminPanel.Views.Windows;
using BankApp.Commands;
using BankApp.Core.Domain.Entities;
using BankApp.Core.Utils;
using BankApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BankApp.AdminPanel.Commands.Auth
{
    public class LoginCommand : BaseCommand
    {
        private readonly LoginViewModel viewModel;
        public LoginCommand(LoginViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            Logger.Log(DateTime.Now.TimeOfDay);
            PasswordBox passwordBox = parameter as PasswordBox;

            if (passwordBox == null)
                return;

            User login = viewModel.DB.LoginRepository.Get(viewModel.Username);

            if (login == null)
            {
                viewModel.LoginErrorVisibility = Visibility.Visible;
                return;
            }

            // string password = passwordBox.Password;
            string password = "1234";
            string passwordHash = SecurityUtil.ComputeSha256Hash(password);

            if (login.PasswordHash == passwordHash)
            {
                Kernel.CurrentUser = login;

                MenuWindow menu = new MenuWindow();
                MenuViewModel menuViewModel = new MenuViewModel(Kernel.DB,menu);

                menuViewModel.CenterGrid = menu.grdCenter;
                menu.DataContext= menuViewModel;    

                viewModel.LoginWindow.Close();
                menu.Show();
            }
            else
            {
                viewModel.LoginErrorVisibility = Visibility.Visible;
                return;
            }
        }
    }
}
