using BankApp.Core.DataAccess.Abstract;
using BankApp.WebBank.Mappers;
using Microsoft.AspNetCore.Mvc;
using WebBank.Models.Client;

namespace BankApp.WebBank.Controllers
{
    public class ClientController : Controller
    {
        private readonly IUnitOfWork db;

        public ClientController(IUnitOfWork db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var clients = db.ClientRepository.Get();

            ClientMapper clientMapper = new ClientMapper();
            List<ClientModel> clientModels = new List<ClientModel>();

            for (int i = 0; i < clients.Count; i++)
            {
                var client = clients[i];
                var clientModel = clientMapper.Map(client);

                clientModel.No = i + 1;
                clientModels.Add(clientModel);
            }

            ClientViewModel viewModel = new ClientViewModel()
            {
                Clients = clientModels
            };

            return View(viewModel);

        }
    }
}
