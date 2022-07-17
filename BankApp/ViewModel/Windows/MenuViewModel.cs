using BankApp.AdminPanel.Commands;
using BankApp.AdminPanel.Commands.Main;
using BankApp.AdminPanel.Commands.Menu;
using BankApp.AdminPanel.ViewModels;
using BankApp.AdminPanel.Views.Windows;
using BankApp.Core.DataAccess.Abstract;
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BankApp.AdminPanel.ViewModel
{
    public class MenuViewModel : BaseWindowViewModel
    {
        public readonly MenuWindow MenuWindow;
        public MenuViewModel(IUnitOfWork db,Window window) : base(db,window)
        {
        }
        public Grid CenterGrid { get; set; }

        public OpenClientCommand OpenClient => new OpenClientCommand(this);
        public OpenCreditCommand OpenCredit => new OpenCreditCommand(this);
        public OpenExchangeCommand OpenExchange => new OpenExchangeCommand(this);
        public OpenCardCommand OpenCard => new OpenCardCommand(this);
        public OpenEmployeeCommand OpenEmployee => new OpenEmployeeCommand(this);
        public OpenBranchCommand OpenBranch => new OpenBranchCommand(this);

    }
}
    