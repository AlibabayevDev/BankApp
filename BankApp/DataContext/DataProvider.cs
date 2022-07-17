using BankApp.AdminPanel.Mappers;
using BankApp.AdminPanel.Model;
using BankApp.Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.DataContext
{
    public class DataProvider
    {
        private readonly IUnitOfWork db;
        public DataProvider(IUnitOfWork db)
        {
            this.db = db;
        }
        public List<EmployeeModel> GetEmployee()
        {
            var employees = db.EmployeeRepository.Get();
            EmployeeMapper employeeMapper = new EmployeeMapper();
            List<EmployeeModel> models = new List<EmployeeModel>();

            for (int i = 0; i < employees.Count; i++)
            {
                var employe = employees[i];

                var EmployeeModel = employeeMapper.Map(employe);
                EmployeeModel.NO = i + 1;

                models.Add(EmployeeModel);
            }

            return models;
        }

        public List<ExchangeModel> GetExchange()
        {
            var exchanges = db.ExchangeRepository.Get();
            ExchangeMapper exchangeMapper = new ExchangeMapper();
            List<ExchangeModel> models = new List<ExchangeModel>();

            for (int i = 0; i < exchanges.Count;i++)
            {
                var exchange = exchanges[i];

                var ExchangeModel = exchangeMapper.Map(exchange);
                ExchangeModel.NO = i + 1;

                models.Add(ExchangeModel);
            }

            return models;
        }

        public List<ClientModel> GetClient()
        {
            var clients = db.ClientRepository.Get();
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

        //public List<ClientModel> ClientCard()
        //{
        //    var clients = db.ClientRepository.GetCard();
        //    ClientMapper clientMapper = new ClientMapper();
        //    List<ClientModel> models = new List<ClientModel>();

        //    for (int i = 0; i < clients.Count; i++)
        //    {
        //        var client = clients[i];

        //        var ClientModel = clientMapper.Map(client);
        //        ClientModel.NO = i + 1;

        //        models.Add(ClientModel);
        //    }

        //    return models;
        //}
        public List<ClientModel> RestoreClient()
        {
            var clients = db.ClientRepository.GetRestore();
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
        public List<CardModel> GetCards()
        {
            var cards = db.CardRepository.Get();
            CardMapper cardMapper = new CardMapper();
            List<CardModel> cardModels = new List<CardModel>();

            for (int i = 0; i < cards.Count; i++)
            {
                var card = cards[i];

                var cardModel = cardMapper.Map(card);
                cardModel.NO = i + 1;

                cardModels.Add(cardModel);
            }

            return cardModels;
        }


        public List<CreditModel> GetCredits()
        {
            var credits = db.CreditRepository.Get();
            CreditMapper creditMapper = new CreditMapper();
            List<CreditModel> creditModels = new List<CreditModel>();

            for (int i = 0; i < credits.Count; i++)
            {
                var credit = credits[i];

                var creditModel = creditMapper.Map(credit);
                creditModel.NO = i + 1;

                creditModels.Add(creditModel);
            }

            return creditModels;
        }

        public List<BranchModel> GetBranch()
        {
            var branches = db.BranchesRepository.Get();
            BranchMapper branchMapper = new BranchMapper();
            List<BranchModel> branchesModel = new List<BranchModel>();

            for (int i = 0; i < branches.Count; i++)
            {
                var credit = branches[i];

                var creditModel = branchMapper.Map(credit);
                creditModel.NO = i + 1;

                branchesModel.Add(creditModel);
            }

            return branchesModel;
        }
    }
}
