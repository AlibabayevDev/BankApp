using BankApp.AdminPanel.Commands;
using BankApp.AdminPanel.Commands.BranchCommand;
using BankApp.AdminPanel.Model;
using BankApp.Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.ViewModel.Controls
{
    public class BranchControlViewModel : BaseControlViewModel<BranchModel>
    {
        public BranchControlViewModel(IUnitOfWork db) : base(db)
        {
        }

        public override string Header => "Branchs";

        public List<BranchModel> Branches { get; set; }

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

        #region Commands        
        public OpenSearchBranch OpenSearch => new OpenSearchBranch(this);
        public SearchCommand SearchCommand => new SearchCommand(this);
        public ShowAllClients ShowAllClients => new ShowAllClients(this);
        public ClearCommand ClearCommand => new ClearCommand(this);
        public SaveCommand Save => new SaveCommand(this);
        public DeleteCommand Delete => new DeleteCommand(this);
        public ExcelExportCommand<BranchModel> ExportExcel => new ExcelExportCommand<BranchModel>(this);
        #endregion

    }
}
