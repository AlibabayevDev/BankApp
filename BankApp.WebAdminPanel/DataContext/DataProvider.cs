using BankApp.AdminPanel.Mappers;
using BankApp.Core.DataAccess.Abstract;
using BankApp.WebAdminPanel.Models.Client;
using BankApp.WebAdminPanel.Models.Exchange;
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

                models.Add(ClientModel);
            }

            return models;
        }
    }
}
