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
    public class ClientCardViewModel : BaseControlViewModel<ClientModel>
    {
        public ClientCardViewModel(IUnitOfWork db) : base(db)
        {
        }

        public Grid CenterGrid { get; set; }

        public List<ClientModel> Cards { get; set; }
        private ObservableCollection<ClientModel> clientCard;
        public ObservableCollection<ClientModel> ClientCard
        {
            get
            {
                return clientCard;
            }
            set
            {
                clientCard = value;
                OnPropertyChanged(nameof(ClientCard));
            }
        }

        public void Inizialize()
        {
            ClientCard = new ObservableCollection<ClientModel>(Cards);
        }

        public override string Header => "Client Cards";
        
    }
}
