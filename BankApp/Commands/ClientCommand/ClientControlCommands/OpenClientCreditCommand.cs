using BankApp.AdminPanel.DataContext;
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
    public class OpenClientCreditCommand : BaseCommand
    {
        private readonly MainClientControlViewModel viewModel;
        public OpenClientCreditCommand(MainClientControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            ClientCreditViewModel clientCreditViewModel = new ClientCreditViewModel(Kernel.DB);

            List<ClientModel> ClientCredit()
            {
                var clients = viewModel.DB.ClientRepository.GetCredits(viewModel.CurrentValue.Id);
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

            clientCreditViewModel.Credits = ClientCredit();
            clientCreditViewModel.Inizialize();

            CreditWindow ClientCredits = new CreditWindow();
            clientCreditViewModel.CenterGrid = ClientCredits.CenterGrid;

            clientCreditViewModel.ErrorDialog = ClientCredits.ErrorDialog;
            ClientCredits.DataContext = clientCreditViewModel;
            ClientCredits.ShowDialog();
        }
    }
}
