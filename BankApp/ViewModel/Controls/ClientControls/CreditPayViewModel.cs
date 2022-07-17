using BankApp.AdminPanel.Commands.ClientCommand.Commands;
using BankApp.AdminPanel.Model;
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
    public class CreditPayViewModel : BaseControlViewModel<ClientModel>
    {
        public CreditPayViewModel(IUnitOfWork db) : base(db)
        {
        }

        public Grid CenterGrid { get; set; }


        #region Command
        public PayCreditCommand payCredit => new PayCreditCommand(this);
        #endregion

        public double PayAmount { get; set; }

        public List<ClientModel> PayCredits { get; set; }
        private ObservableCollection<ClientModel> clientPayCredit;
        public ObservableCollection<ClientModel> ClientPayCredit
        {
            get
            {
                return clientPayCredit;
            }
            set
            {
                clientPayCredit = value;
                OnPropertyChanged(nameof(ClientPayCredit));
            }
        }

        public void Inizialize()
        {
            ClientPayCredit = new ObservableCollection<ClientModel>(PayCredits);
        }

        public override string Header => "Client Credit";
    }
}
