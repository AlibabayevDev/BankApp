using BankApp.AdminPanel.Commands.CreditCommand;
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

namespace BankApp.AdminPanel.ViewModel.Controls
{
    public class CreditControlViewModel : BaseControlViewModel<CreditModel>
    {
        public CreditControlViewModel(IUnitOfWork db) : base(db)
        {
        }

        //public void Initialize()
        //{
        //    Values = new ObservableCollection<CreditModel>(AllValues);

        //}

        public OpenSearchCredit OpenSearch => new OpenSearchCredit(this);
        public SearchCreditCommand SearchCommand => new SearchCreditCommand(this);
        public ShowAllCreditsCommand ShowAll => new ShowAllCreditsCommand(this);
        public ClearCommand ClearCommand => new ClearCommand(this);
        public SaveCreditCommand Save => new SaveCreditCommand(this);
        public DeleteCreditCommand Delete => new DeleteCreditCommand(this);
        public RejectCommand<CreditModel> Reject => new RejectCommand<CreditModel>(this);

        public override string Header => "Credit Number";



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

        public List<BranchModel> Branches { get; set; }

        private BranchModel selectedBranch;
        public BranchModel SelectedBranch
        {
            get => selectedBranch;
            set
            {
                selectedBranch = value;
                OnPropertyChanged(nameof(SelectedBranch));
            }
        }

        #endregion



        #region search properties
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

        private string searchTextAmount;
        public string SearchTextAmount
        {
            get
            {
                return searchTextAmount;
            }
            set
            {
                searchTextAmount = value;
                OnPropertyChanged(SearchTextAmount);
            }
        }

        private string searchTextClient;
        public string SearchTextClient
        {
            get
            {
                return searchTextClient;
            }
            set
            {
                searchTextClient = value;
                OnPropertyChanged(SearchTextClient);
            }
        }

        private string searchTextBranch;
        public string SearchtextBranch
        {
            get
            {
                return searchTextBranch;
            }
            set
            {
                searchTextBranch = value;
                OnPropertyChanged(searchTextBranch);
            }
        }
        #endregion
    }
}
