using BankApp.AdminPanel.Commands;
using BankApp.AdminPanel.Commands.CardCommand;
using BankApp.AdminPanel.Commands.ClientCommand;
using BankApp.AdminPanel.Commands.ClientCommand.ClientControlCommands;
using BankApp.AdminPanel.Commands.ClientCommand.Commands;
using BankApp.AdminPanel.Commands.ClientCommand.ExportWord;
using BankApp.AdminPanel.Commands.Menu;
using BankApp.AdminPanel.Enums;
using BankApp.AdminPanel.Model;
using BankApp.Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BankApp.AdminPanel.ViewModel.Controls.ClietnControls
{
    public class MainClientControlViewModel : BaseControlViewModel<ClientModel>
    {
        public Grid CenterGridMainClient { get; set; }
        public Grid CardGrid { get; set; }
        public MainClientControlViewModel(IUnitOfWork db) : base(db)
        {
        }
        #region Commands
        public SaveCommand Save => new SaveCommand(this);
        public DeleteCommand Delete => new DeleteCommand(this);
        public OpenClientControl OpenClientControl => new OpenClientControl(this);
        public OpenRestoreCommand Restore => new OpenRestoreCommand(this);
        public ExcelExportCommand<ClientModel> ExportExcel => new ExcelExportCommand<ClientModel>(this);
        public Sablon Sablon => new Sablon(this);
        public Cancel Cancel => new Cancel(this);
        public Edit Edit => new Edit(this);
        public OpenClientCardCommand ClientCard => new OpenClientCardCommand(this);
        public OpenClientCreditCommand Credit => new OpenClientCreditCommand(this);
        public ClearMainControl ClearMainControl => new ClearMainControl(this);
        #endregion
        public override string Header => "Client Editor";

        private byte currentSituation = (byte)Situations.NORMAL;

        public byte CurrentSituation
        {
            get
            {
                return currentSituation;
            }
            set
            {
                currentSituation = value;
                OnPropertyChanged(nameof(CurrentSituation));
            }
        }

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
