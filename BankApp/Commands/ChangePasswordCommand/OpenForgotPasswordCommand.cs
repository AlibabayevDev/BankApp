using BankApp.AdminPanel.DataContext;
using BankApp.AdminPanel.ViewModel.Email;
using BankApp.AdminPanel.Views.Email;
using BankApp.Commands;
using BankApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.ChangePasswordCommand
{
    public class OpenForgotPasswordCommand : BaseCommand
    {
        private readonly LoginViewModel viewModel;

        public OpenForgotPasswordCommand(LoginViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            ForgotPasswordWindow window = new ForgotPasswordWindow();
            ForgotPasswordViewModel forgotPasswordViewModel = new ForgotPasswordViewModel(Kernel.DB, window);
            window.DataContext = forgotPasswordViewModel;
            window.Show();
            viewModel.LoginWindow.Close();
        }
    }
}
