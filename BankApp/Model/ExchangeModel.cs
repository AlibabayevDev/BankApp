using BankApp.AdminPanel.Attributes;
using BankApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Model
{
    public class ExchangeModel : BaseModel
    {
        //public int IdClient { get; set; }
        [ExcelDisplay(ColumnNo = 1, Name = "Name")]
        public ClientModel Client { get; set; }


        [ExcelDisplay(ColumnNo = 2, Name = "Phone number")]
        public string Phone { get; set; }

        [ExcelDisplay(ColumnNo = 3, Name = "Exchange from amount")]
        public double AmountFromExchange { get; set; }


        [ExcelDisplay(ColumnNo = 4, Name = "Exchange to amount")]
        public double AmountToExchange { get; set; }

        [ExcelDisplay(ColumnNo = 5, Name = "Convert from currency")]
        public string ConvertFromCurrency { get; set; }


        [ExcelDisplay(ColumnNo = 6, Name = "Convert to currency")]
        public string ConvertToCurrency { get; set; }

        [ExcelDisplay(ColumnNo = 7, Name = "Date")]
        public DateTime Date { get; set; } = DateTime.Now;

        public double ExchangeRate { get; set; }

        public override bool IsValid(out string message)
        {

            if (string.IsNullOrWhiteSpace(Phone))
            {
                message = ValidationHelper.GetRequiredMessage("Phone");
                return false;
            }


            if (string.IsNullOrWhiteSpace(AmountToExchange.ToString()))
            {
                message = ValidationHelper.GetRequiredMessage("Amount to exchange");
                return false;
            }

            if (string.IsNullOrWhiteSpace(AmountFromExchange.ToString()))
            {
                message = ValidationHelper.GetRequiredMessage("Amount from exchange");
                return false;
            }


            if (string.IsNullOrWhiteSpace(ConvertFromCurrency))
            {
                message = ValidationHelper.GetRequiredMessage("Convert from currency");
                return false;
            }


            if (string.IsNullOrWhiteSpace(ConvertToCurrency))
            {
                message = ValidationHelper.GetRequiredMessage("Convert to currency");
                return false;
            }


            if (string.IsNullOrWhiteSpace(Date.ToString()))
            {
                message = ValidationHelper.GetRequiredMessage("Date");
                return false;
            }


            if (string.IsNullOrWhiteSpace(Client.ToString()))
            {
                message = ValidationHelper.GetRequiredMessage("Customer");
                return false;
            }


            message = string.Empty;
            return true;
        }


        public override object Clone()
        {
            return new ExchangeModel()
            {
                Id = Id,
                Client = Client?.Clone() as ClientModel,
                Phone = Phone,
                AmountToExchange = AmountToExchange,
                AmountFromExchange = AmountFromExchange,
                ConvertFromCurrency = ConvertFromCurrency,
                ConvertToCurrency = ConvertToCurrency,
                Date = Date,
            };
        }

        public override string ToExcelString()
        {
            return $"{Client?.Name}";
        }
    }
}
 