using BankApp.AdminPanel.Commands.ClientCommand.ClientControlCommands;
using BankApp.AdminPanel.Commands.Menu;
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
    public class ClientCreditViewModel : BaseControlViewModel<ClientModel>
    {
        public ClientCreditViewModel(IUnitOfWork db) : base(db)
        {
        }

        public Grid CenterGrid { get; set; }


        #region

        public OpenCreditPayControl OpenPay => new OpenCreditPayControl(this);

        #endregion



        public List<ClientModel> Credits { get; set; }
        private ObservableCollection<ClientModel> clientCredit;
        public ObservableCollection<ClientModel> ClientCredit
        {
            get
            {
                return clientCredit;
            }
            set
            {
                clientCredit = value;
                OnPropertyChanged(nameof(ClientCredit));
            }
        }

        public void Inizialize()
        {
            ClientCredit = new ObservableCollection<ClientModel>(Credits);
        }

        public override string Header => "Client Credit";
        
    }
}
