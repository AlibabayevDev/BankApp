using BankApp.AdminPanel.Commands.ClientCommand;
using BankApp.AdminPanel.Commands.ClientCommand.ClientControlCommands;
using BankApp.AdminPanel.Commands.ClientCommand.Commands;
using BankApp.AdminPanel.Enums;
using BankApp.AdminPanel.Model;
using BankApp.AdminPanel.Views.Controls;
using BankApp.Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BankApp.AdminPanel.ViewModel.Controls
{
    public class ClientControlViewModel : BaseControlViewModel<ClientModel>
    {
        public ClientControlViewModel(IUnitOfWork db) : base(db)
        {
        }
        public Grid CenterGrid { get; set; }

        #region Commands

        public CopyFIN CopyFIN => new CopyFIN(this);
        public CopySeriya CopySeriya => new CopySeriya(this);
        public CopyID CopyID => new CopyID(this);

        public OpenMainControlClient OpenMainControlClient => new OpenMainControlClient(this);
        public ShowAllClients ShowAllClients => new ShowAllClients(this);
        public ClearCommand ClearCommand => new ClearCommand(this);
        public SearchCommand SearchCommand => new SearchCommand(this);
        public AddClientCommand AddClientCommand => new AddClientCommand(this);
        #endregion
        public override string Header => "Account Number";    
        
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
        private string searchTextFin;
        public string SearchTextFIN
        {
            get
            {
                return searchTextFin;
            }
            set
            {
                searchTextFin = value;
                OnPropertyChanged(SearchTextFIN);
            }
        }
        private string searchTextseriya;
        public string SearchTextSeriya
        {
            get
            {
                return searchTextseriya;
            }
            set
            {
                searchTextseriya = value;
                OnPropertyChanged(SearchTextSeriya);
            }
        }
        private string searchTextsurname;
        public string SearchTextSurname
        {
            get
            {
                return searchTextsurname;
            }
            set
            {
                searchTextsurname = value;
            }
        }
        private string searchTextfathername;
        public string SearchTextFatherName
        {
            get
            {
                return searchTextfathername;
            }
            set
            {
                searchTextfathername = value;
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
        #endregion SearchText  
    }
}
