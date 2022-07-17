using BankApp.AdminPanel.Commands.ChangePasswordCommand;
using BankApp.AdminPanel.ViewModels;
using BankApp.AdminPanel.Views.Email;
using BankApp.Core.DataAccess.Abstract;
using System.Windows;
using System.Windows.Input;

namespace BankApp.AdminPanel.ViewModel.Email
{
    public class VerifyCodeViewModel : BaseWindowViewModel
    {
        public readonly VerifyCodeWindow verifyCodeWindow;

        public VerifyCodeViewModel(IUnitOfWork db, VerifyCodeWindow verifyCodeWindow) : base(db, verifyCodeWindow)
        {
            this.verifyCodeWindow = verifyCodeWindow;
        }

        public string VerificationCode { get; set; }

        //   public OpenVerifyCodeCommand Verify => new OpenVerifyCodeCommand(this);

        public ICommand Verify => new OpenConfirmPasswordCommand(this);

        private Visibility incorrectCode = Visibility.Collapsed;
        public Visibility IncorrectCode
        {
            get
            {
                return incorrectCode;
            }
            set
            {
                incorrectCode = value;
                OnPropertyChanged(nameof(IncorrectCode));
            }
        }
    }
}
