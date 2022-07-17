using BankApp.AdminPanel.Commands.EmployeeCommand;
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
using System.Windows.Controls;
using SearchCommand = BankApp.AdminPanel.Commands.EmployeeCommand.SearchCommand;
using ShowAllClients = BankApp.AdminPanel.Commands.EmployeeCommand.ShowAllClients;

namespace BankApp.AdminPanel.ViewModel.Controls
{
    public class EmployeeControlViewModel : BaseControlViewModel<EmployeeModel>
    {
        public EmployeeControlViewModel(IUnitOfWork db) : base(db)
        {

        }
        public Grid CenterGrid { get; set; }
        public override string Header => "Employee";

        public override void OnCurrentValueChange()
        {
            SelectedBranch = (BranchModel)CurrentValue?.Branch?.Clone();
        }

        #region Commands
        public SaveEmployeeCommand Save => new SaveEmployeeCommand(this);
        public DeleteCommand Delete => new DeleteCommand(this);
        public OpenSearchEmployee OpenSearch => new OpenSearchEmployee(this);
        public SearchCommand SearchCommand => new SearchCommand(this);
        public ShowAllClients ShowAllClients => new ShowAllClients(this);

        #endregion

        #region comboBox properties
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

        #region SearchText
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
        private string searchTextSurname;
        public string SearchTextSurname
        {
            get
            {
                return searchTextSurname;
            }
            set
            {
                searchTextSurname = value;
            }
        }
        private string searchTextspeciality;
        public string SearchTextSpeciality
        {
            get
            {
                return searchTextspeciality;
            }
            set
            {
                searchTextspeciality = value;
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

        private string searchTextAddress;
        public string SearchTextAddress
        {
            get
            {
                return searchTextAddress;
            }
            set
            {
                searchTextAddress = value;
            }
        }

        
        #endregion SearchText  
    }
}
