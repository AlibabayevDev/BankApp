using BankApp.Core.Domain.Entities;
using BankApp.WebAdminPanel.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Mappers
{
    public class ClientMapper : BaseMapper<Client, ClientModel>
    {
        public override Client Map(ClientModel model)
        {
            return new Client()
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
                PassportEndTime = model.PassportEndTime,
                BirthDate = model.BirthDate,
                Country = model.Country,
                City = model.City,
                AccountingTime=model.AccountingTime,
                PassportSubmissionTime=model.PassportSubmissionTime,
            };
        }

        public override ClientModel Map(Client entity)
        {
            return new ClientModel()
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
                AccountingTime=entity.AccountingTime,
                PassportSubmissionTime = entity.PassportSubmissionTime,
            };
        }
    }
}
