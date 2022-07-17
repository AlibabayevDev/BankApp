using BankApp.Core.Domain.Entities;
using BankApp.WebAdminPanel.Models.Exchange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Mappers
{
    public class ExchangeMapper : BaseMapper<Exchange, ExchangeModel>
    {
        private readonly ClientMapper clientMapper = new ClientMapper();

        public override Exchange Map(ExchangeModel model)
        {
            return new Exchange()
            {
                Id = model.Id,
                Client = clientMapper.Map(model.Client),
                Phone = model.Phone,
                AmountFromExchange = model.AmountFromExchange,
                AmountToExchange = model.AmountToExchange,
                ConvertFromCurrency = model.ConvertFromCurrency,
                ConvertToCurrency = model.ConvertToCurrency,
                Date = model.Date,
            };
        }

        public override ExchangeModel Map(Exchange entity)
        {
            return new ExchangeModel()
            {
                Id = entity.Id,
                Client = clientMapper.Map(entity.Client),
                Phone = entity.Phone,
                AmountFromExchange = entity.AmountFromExchange,
                AmountToExchange = entity.AmountToExchange,
                ConvertFromCurrency = entity.ConvertFromCurrency,
                ConvertToCurrency = entity.ConvertToCurrency,
                Date = entity.Date,
            };
        }
    }
}
