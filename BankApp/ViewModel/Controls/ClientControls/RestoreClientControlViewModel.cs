using BankApp.AdminPanel.Commands.ClientCommand;
using BankApp.AdminPanel.Commands.ClientCommand.ClientControlCommands;
using BankApp.AdminPanel.Commands.ClientCommand.Commands;
using BankApp.AdminPanel.DataContext;
using BankApp.AdminPanel.Model;
using BankApp.AdminPanel.ViewModel.Controls.ClietnControls;
using BankApp.Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BankApp.AdminPanel.ViewModel.Controls.ClientControls
{
    public class RestoreClientControlViewModel : BaseControlViewModel<ClientModel>
    {
        public RestoreClientControlViewModel(IUnitOfWork db) : base(db)
        {
        }

        public Grid CenterGrid { get; set; }
        public List<ClientModel> Restore { get; set; }

        private ObservableCollection<ClientModel> Restorevalues;
        public ObservableCollection<ClientModel> RestoreValues
        {
            get
            {
                return Restorevalues;
            }
            set
            {
                Restorevalues = value;
                OnPropertyChanged(nameof(RestoreValues));
            }
        }

        public void Inizialize()
        {
            RestoreValues = new ObservableCollection<ClientModel>(Restore);
        }

        public override string Header => "Restore";
        public RestoreShowAllClients ShowAllClients => new RestoreShowAllClients(this);
        public RestoreSearchCommand SearchCommand => new RestoreSearchCommand(this);
        public RestoreCommand RestoreCommand => new RestoreCommand(this);
        public BackMainClientControlCommand BackMainClientControlCommand => new BackMainClientControlCommand(this);


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
