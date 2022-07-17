using BankApp.AdminPanel.Commands.ExchangeCommand;
using BankApp.AdminPanel.Commands.ExchangeCommand.CalculateCommand;
using BankApp.AdminPanel.Commands.ExchangeCommand.Commands;
using BankApp.AdminPanel.Enums;
using BankApp.AdminPanel.Model;
using BankApp.Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BankApp.AdminPanel.ViewModel.Controls
{
    public class ExchangeControlViewModel : BaseControlViewModel<ExchangeModel>
    {
        public ExchangeControlViewModel(IUnitOfWork db) : base(db)
        {

        }

        public Grid CenterGrid { get; set; }
        public override string Header => "Exchange";

        #region Command
        public SaveExchangeCommand Save => new SaveExchangeCommand(this);
        public DeleteCommand Delete => new DeleteCommand(this);
        public OpenSearchExchange OpenSearch => new OpenSearchExchange(this);
        public SearchCommand SearchCommand => new SearchCommand(this);
        public ShowAllClients ShowAllClients => new ShowAllClients(this);
        public OpenCalculateCommand OpenCalculateWindow => new OpenCalculateCommand(this);
        public CalculateCommand calculateCommand => new CalculateCommand(this);
        #endregion

         public override void OnCurrentValueChange()
        {
            SelectedClient = (ClientModel) CurrentValue?.Client?.Clone();
        }


        private double exchangeRate;
        public double ExchangeRate
        {
            get
            {
                return exchangeRate;
            }
            set
            {
                exchangeRate = value;
                OnPropertyChanged(nameof(ExchangeRate));
                CurrentValue.ExchangeRate = ExchangeRate;
                AmountFromExchange = ExchangeRate * AmountToExchange;
            }
        }



        private double amountToExchange;
        public double AmountToExchange
        {
            get
            {
                return amountToExchange;
            }
            set
            {
                amountToExchange = value;
                OnPropertyChanged(nameof(AmountToExchange));

                AmountFromExchange = ExchangeRate * AmountToExchange;

                //CalculateDataBasedOnAzn();
            }
        }


        private double amountFromExchange;
        public double AmountFromExchange
        {
            get
            {
                return amountFromExchange;
            }
            set
            {
                amountFromExchange = value;
                AmountFromExchange=CurrentValue.AmountFromExchange;
                OnPropertyChanged(nameof(AmountFromExchange));
            }
        }

        public double CalculateDataBasedOnAzn()
        {

            return AmountFromExchange;
        }


        #region comboBox properties
        public List<ClientModel> Clients { get; set; }

        private ClientModel selectedClient;
        public ClientModel SelectedClient
        {
            get => selectedClient;
            set
            {
                selectedClient = value;
                OnPropertyChanged(nameof(SelectedClient));
            }
        }

        #endregion
        #region Search
        private string searchTextname;
        public string SearchTextName
        {
            get
            {
                return searchTextname;
            }
            set
            {
                searchTextname = value;
                OnPropertyChanged(SearchTextName);
            }
        }
        
        private string searchTextphone;
        public string SearchTextPhone
        {
            get
            {
                return searchTextphone;
            }
            set
            {
                searchTextphone = value;
            }
        }
        #endregion
     
    }
}
