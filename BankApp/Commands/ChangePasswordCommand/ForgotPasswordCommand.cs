using BankApp.AdminPanel.DataContext;
using BankApp.AdminPanel.ViewModel.Email;
using BankApp.AdminPanel.Views.Email;
using BankApp.Commands;
using BankApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace BankApp.AdminPanel.Commands.ChangePasswordCommand
{
    public class ForgotPasswordCommand : BaseCommand
    {
        private readonly ForgotPasswordViewModel viewModel;

        public ForgotPasswordCommand(ForgotPasswordViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            User login = viewModel.DB.LoginRepository.Get(viewModel.Username);
            if (login == null)
            {
                viewModel.ErrorMailMessage = Visibility.Visible;
                return;
            }
          
            try
            {
                SmtpClient client = new SmtpClient()
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential()
                    {
                        UserName = viewModel.Username,
                        Password = "euzbnbiytebfiomw"
                    }
                };

                Random rand = new Random();
                string randomCode;
                randomCode = rand.Next(999999).ToString();


                MailAddress fromMail = new MailAddress("nahidmir101@gmail.com", "BankApp");
                MailAddress toMail = new MailAddress(viewModel.Username, "BankApp");
                MailMessage message = new MailMessage()
                {
                    From = fromMail,
                    Subject = "Password",
                };
                message.Body = $"your reset password is {randomCode}";
                message.To.Add(toMail);
                client.Send(message);

                VerifyCodeWindow verifyCodeWindow = new VerifyCodeWindow();
                VerifyCodeViewModel verifyCodeViewModel = new VerifyCodeViewModel(Kernel.DB, verifyCodeWindow);
                verifyCodeWindow.DataContext = verifyCodeViewModel;
                verifyCodeWindow.Show();
                viewModel.forgotPasswordWindow.Close();

                if (randomCode == verifyCodeViewModel.VerificationCode)
                {
                    ConfirmPasswordWindow confirmPasswordWindow = new ConfirmPasswordWindow();
                    ConfirmPasswordViewModel confirmPasswordViewModel = new ConfirmPasswordViewModel(Kernel.DB, confirmPasswordWindow);
                    confirmPasswordWindow.DataContext = confirmPasswordViewModel;
                    verifyCodeWindow.Close();
                    confirmPasswordWindow.Show();
                }
                else
                {
                    verifyCodeViewModel.IncorrectCode = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
