using BankApp.AdminPanel.DataContext;
using BankApp.AdminPanel.ViewModel.Email;
using BankApp.AdminPanel.Views.Email;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.ChangePasswordCommand
{
    public class OpenConfirmPasswordCommand : BaseCommand
    {
        private readonly VerifyCodeViewModel viewModel;

        public OpenConfirmPasswordCommand(VerifyCodeViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            ConfirmPasswordWindow window = new ConfirmPasswordWindow();
            ConfirmPasswordViewModel confirmPasswordViewModel = new ConfirmPasswordViewModel(Kernel.DB, window);
            window.DataContext = confirmPasswordViewModel;
            viewModel.verifyCodeWindow.Close();
            window.Show();
        }
    }
}
