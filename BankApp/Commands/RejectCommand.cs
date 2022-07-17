using BankApp.AdminPanel.Enums;
using BankApp.AdminPanel.Model;
using BankApp.AdminPanel.ViewModel;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.ExchangeCommand
{
    public class RejectCommand<T> : BaseCommand where T : BaseModel, new()
    {
        private readonly BaseControlViewModel<T> viewModel;
        public RejectCommand(BaseControlViewModel<T> viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            viewModel.CurrentValue = null;
            viewModel.CurrentSituation = (byte)Situations.NORMAL;
            viewModel.CurrentValue= new T();
        }
    }
}