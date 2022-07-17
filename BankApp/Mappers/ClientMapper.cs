using BankApp.AdminPanel.Model;
using BankApp.Core.Domain.Entities;

namespace BankApp.AdminPanel.Mappers
{
    public class ClientMapper : BaseMapper<Client, ClientModel>
    {
        public override Client Map(ClientModel model)
        {
            var client = new Client()
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                FatherName = model.FatherName,
                FIN = model.FIN,
                Seriya = model.Seriya,
                Phone = model.Phone,
                Adress = model.Adress,
                AccountNumber = model.AccountNumber,
                PlaceOfBirth = model.PlaceOfBirth,
                Citizenship = model.Citizenship,
                Studies = model.Studies,
                Email = model.Email,
                PassportEndTime= model.PassportEndTime,
                BirthDate = model.BirthDate,
                Country = model.Country,
                City = model.City,
                AccountingTime = model.AccountingTime,
                PassportSubmissionTime = model.PassportSubmissionTime,
            };

            if(model.Card != null)
            {
                var cardMapper = new CardMapper();

                model.Card.Client = null;
                client.Card = cardMapper.Map(model.Card);
                client.Card.Client = client;
            }

            if (model.Credit != null)
            {
                var creditMapper = new CreditMapper();

                model.Credit.Client = null;
                client.Credit = creditMapper.Map(model.Credit);
                client.Credit.Client = client;
            }

            return client;
        }

        public override ClientModel Map(Client entity)
        {
            var client = new ClientModel()
            {                
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
                FatherName = entity.FatherName,
                FIN = entity.FIN,
                Seriya = entity.Seriya,
                Phone = entity.Phone,
                Adress = entity.Adress,
                AccountNumber = entity.AccountNumber,
                PlaceOfBirth = entity.PlaceOfBirth,
                Citizenship = entity.Citizenship,
                Studies = entity.Studies,
                Email = entity.Email,
                PassportEndTime = entity.PassportEndTime,
                BirthDate = entity.BirthDate,
                Country = entity.Country,
                City = entity.City,
                AccountingTime = entity.AccountingTime,
                PassportSubmissionTime = entity.PassportSubmissionTime,
            };

            if (entity.Card != null)
            {
                var cardMapper = new CardMapper();

                entity.Card.Client = null;
                client.Card = cardMapper.Map(entity.Card);
                client.Card.Client = client;
            }

            if(entity.Credit != null)
            {
                var creditMapper = new CreditMapper();

                entity.Credit.Client = null;
                client.Credit = creditMapper.Map(entity.Credit);
                client.Credit.Client = client;
            }

            return client;
        }
    }
}