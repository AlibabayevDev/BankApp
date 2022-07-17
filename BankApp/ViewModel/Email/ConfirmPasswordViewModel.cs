using BankApp.AdminPanel.Commands.ChangePasswordCommand;
using BankApp.AdminPanel.ViewModels;
using BankApp.AdminPanel.Views.Email;
using BankApp.Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.ViewModel.Email
{
    public class ConfirmPasswordViewModel : BaseWindowViewModel
    {
        public readonly ConfirmPasswordWindow ConfirmPasswordWindow;

        public ConfirmPasswordViewModel(IUnitOfWork db, ConfirmPasswordWindow confirmPasswordWindow) : base(db, confirmPasswordWindow)
        {
            this.ConfirmPasswordWindow = confirmPasswordWindow;
        }


        public string ConfirmPassword { get; set; }
        public ConfirmPasswordCommand Confirm => new ConfirmPasswordCommand(this);
    }
}
