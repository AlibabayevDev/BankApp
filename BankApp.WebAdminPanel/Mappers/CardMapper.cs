
using BankApp.AdminPanel.Mappers;
using BankApp.Core.Domain.Entities;
using BankApp.WebAdminPanel.Models.Card;

namespace BankApp.WebAdminPanel.Mappers
{
    public class CardMapper : BaseMapper<Card, CardModel>
    {
        private readonly ClientMapper clientMapper = new ClientMapper();

        public override Card Map(CardModel model)
        {
            var card = new Card()
            {
                Id = model.Id,
                Client = clientMapper.Map(model.Client),
                ClientId = model.ClientId,
                TypeCard = model.TypeCard,
                CardNumber = model.CardNumber,
                EndDate = model.EndDate,
            };

            if (model.Client != null)
            {
                var clientMapper = new ClientMapper();

                card.Client.Card = null;
                card.Client = clientMapper.Map(model.Client);
                card.Client.Card = card;
            }

            return card;
        }

        public override CardModel Map(Card entity)
        {
            var card = new CardModel()
            {
                Id = entity.Id,
                Client = clientMapper.Map(entity.Client),
                ClientId =entity.ClientId,
                TypeCard = entity.TypeCard,
                CardNumber = entity.CardNumber,
                EndDate = entity.EndDate,
            };

            if (entity.Client != null)
            {
                var clientMapper = new ClientMapper();
            }

            return card;
        }
    }
}