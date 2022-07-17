using BankApp.AdminPanel.DataContext;
using BankApp.AdminPanel.Enums;
using BankApp.AdminPanel.Mappers;
using BankApp.AdminPanel.Model;
using BankApp.AdminPanel.ViewModel.Controls.ClientControls;
using BankApp.AdminPanel.ViewModel.Controls.ClietnControls;
using BankApp.AdminPanel.Views.Controls.ClientsControls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.ClientCommand.ClientControlCommands
{
    public class OpenClientCardCommand : BaseCommand
    {
        private readonly MainClientControlViewModel viewModel;
        public OpenClientCardCommand(MainClientControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            viewModel.CardGrid.Children.Clear();

            ClientCardViewModel clientCardViewModel = new ClientCardViewModel(Kernel.DB);

            List<ClientModel> ClientCard()
            {
                var clients = viewModel.DB.ClientRepository.GetCard(viewModel.CurrentValue.Id);
                ClientMapper clientMapper = new ClientMapper();
                List<ClientModel> models = new List<ClientModel>();

                for (int i = 0; i < clients.Count; i++)
                {
                    var client = clients[i];

                    var ClientModel = clientMapper.Map(client);
                    ClientModel.NO = i + 1;

                    models.Add(ClientModel);
                }

                return models;
            }

            clientCardViewModel.Cards = ClientCard();
            clientCardViewModel.Inizialize();

            ClientCardControl ClientCards = new ClientCardControl();
            clientCardViewModel.ErrorDialog = ClientCards.ErrorDialog;
            clientCardViewModel.CenterGrid = ClientCards.CenterGrid;


            for(int i = 0; i < clientCardViewModel.Cards.Count; i++)
            {
                if (clientCardViewModel.Cards[i].Card.IsDeleted != true)
                {
                    clientCardViewModel.Cards[i].Card.CardStatus = "Active";
                }
                else
                {
                    clientCardViewModel.Cards[i].Card.CardStatus = "Blocked";
                }
            }
            
            viewModel.CurrentSituation = (int)ClientSituation.EDIT;
            ClientCards.DataContext = clientCardViewModel;

            viewModel.CardGrid.Children.Add(ClientCards);
        }
    }
}
