using BankApp.AdminPanel.Commands;
using BankApp.AdminPanel.Commands.CardCommand;
using BankApp.AdminPanel.Commands.ExchangeCommand;
using BankApp.AdminPanel.Enums;
using BankApp.AdminPanel.Model;
using BankApp.Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchCommand = BankApp.AdminPanel.Commands.CardCommand.SearchCommand;

namespace BankApp.AdminPanel.ViewModel.Controls
{
    public class CardControlViewModel : BaseControlViewModel<CardModel>
    {
        public CardControlViewModel(IUnitOfWork db) : base(db)
        {
        }


        //public void Initialize()
        //{
        //    Values = new ObservableCollection<CardModel>(AllValues);
        //    CurrentSituation = (byte)Situations.NORMAL;
        //}


        #region search properties
        public SearchCommand SearchCommand => new SearchCommand(this);
        public OpenSearchCard OpenSearch => new OpenSearchCard(this);
        public ClearCommand ClearCommand => new ClearCommand(this);
        public ShowAllCardsCommand ShowAll => new ShowAllCardsCommand(this);
        #endregion


        public SaveCardCommand Save => new SaveCardCommand(this);

        public DeleteCardCommand Delete => new DeleteCardCommand(this);
        public RejectCommand<CardModel> Reject => new RejectCommand<CardModel>(this);
        public ExcelExportCommand<CardModel> ExportExcel => new ExcelExportCommand<CardModel>(this);

        public override string Header => "Card Number";

        public override void OnCurrentValueChange()
        {
            SelectedClient = (ClientModel) CurrentValue?.Client?.Clone();
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


        private string searchTextNo;
        public string SearchTextNo
        {
            get
            {
                return searchTextNo;
            }
            set
            {
                searchTextNo = value;
                OnPropertyChanged(SearchTextNo);
            }
        }


        private string searchTextName;
        public string SearchTextName
        {
            get
            {
                return searchTextName;
            }
            set
            {
                searchTextName = value;
                OnPropertyChanged(SearchTextName);
            }
        }


        private string searchTextCardNumber;
        public string SearchTextCardNumber
        {
            get
            {
                return searchTextCardNumber;
            }
            set
            {
                searchTextCardNumber = value;
                OnPropertyChanged(SearchTextCardNumber);
            }
        }


        private string searchTextTypeCard;
        public string SearchTextTypeCard
        {
            get
            {
                return searchTextTypeCard;
            }
            set
            {
                searchTextTypeCard = value;
                OnPropertyChanged(SearchTextTypeCard);
            }
        }
    }
}
