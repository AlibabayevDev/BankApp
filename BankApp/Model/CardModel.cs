using BankApp.AdminPanel.Attributes;
using BankApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Model
{
    public class CardModel : BaseModel
    {
        [ExcelDisplay(ColumnNo = 1, Name = "Name")]
        public ClientModel Client { get; set; } 


        [ExcelDisplay(ColumnNo = 2, Name = "Type card")]
        public string? TypeCard { get; set; }
       

        [ExcelDisplay(ColumnNo = 3, Name = "Card number")]
        public string CardNumber { get; set; }


        [ExcelDisplay(ColumnNo = 4, Name = "End date")]
        public DateTime EndDate { get; set; } = DateTime.Now;
        public string CardStatus { get; set; }
        public bool IsDeleted { get; set; }

        public override object Clone()
        {
            var cardModel = new CardModel()
            {
                Id = Id,
                TypeCard = TypeCard,
                CardNumber = CardNumber,
                EndDate = EndDate,
                IsDeleted = IsDeleted,
                NO = NO,
            };

            if (Client != null)
            {
                Client.Card = null;

                cardModel.Client = Client?.Clone() as ClientModel;
                cardModel.Client.Card = cardModel;

                Client.Card = this;
            }

            return cardModel;
        }


        public override bool IsValid(out string message)
        {
            if (string.IsNullOrWhiteSpace(TypeCard))
            {
                message = ValidationHelper.GetRequiredMessage("Type card");
                return false;
            }

            if (string.IsNullOrWhiteSpace(CardNumber))
            {
                message = ValidationHelper.GetRequiredMessage("Card number");
                return false;
            }


            if (string.IsNullOrWhiteSpace(EndDate.ToString()))
            {
                message = ValidationHelper.GetRequiredMessage("Card's end date");
                return false;
            }

            message = string.Empty; 
            return true;
        }

        public override string ToExcelString()
        {
            return $"{Client.Name}";
        }
    }
}
