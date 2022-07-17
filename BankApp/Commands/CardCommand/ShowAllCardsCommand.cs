using BankApp.AdminPanel.Model;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.CardCommand
{
    public class ShowAllCardsCommand : BaseCommand
    {
        private readonly CardControlViewModel viewModel;

        public ShowAllCardsCommand(CardControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            var models = viewModel.AllValues;
            viewModel.Values = new ObservableCollection<CardModel>(models);
        }
    }
}
