using BankApp.AdminPanel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Model
{
    public class ClientModel : BaseModel
    {
        public CardModel Card { get; set; }
        public CreditModel Credit { get; set; }

        [ExcelDisplay(ColumnNo = 1, Name ="Name")]
        public string Name { get; set; }
        [ExcelDisplay(ColumnNo = 2, Name = "Surname")]
        public string Surname { get; set; }
        [ExcelDisplay(ColumnNo = 3, Name = "Father Name")]
        public string FatherName { get; set; }
        [ExcelDisplay(ColumnNo = 4, Name = "FIN")]
        public string FIN { get; set; }
        [ExcelDisplay(ColumnNo = 5, Name = "Seriya")]
        public string Seriya { get; set; }
        [ExcelDisplay(ColumnNo = 6, Name = "Phone")]
        public string Phone { get; set; }
        [ExcelDisplay(ColumnNo = 7, Name = "Adress")]
        public string Adress { get; set; }
        [ExcelDisplay(ColumnNo = 8, Name = "AccountNumber")]
        public int AccountNumber { get; set; }
        [ExcelDisplay(ColumnNo = 9, Name = "PlaceOfBirth")]
        public string PlaceOfBirth { get; set; }
        [ExcelDisplay(ColumnNo = 10, Name = "Citizenship")]
        public string Citizenship { get; set; }
        [ExcelDisplay(ColumnNo = 11, Name = "Studies")]
        public string Studies { get; set; }
        [ExcelDisplay(ColumnNo = 12, Name = "Email")]
        public string Email { get; set; }
        [ExcelDisplay(ColumnNo = 13, Name = "PassportEndTime")]
        public DateTime PassportEndTime { get; set; }
        [ExcelDisplay(ColumnNo = 14, Name = "BirthDate")]
        public DateTime BirthDate { get; set; } = DateTime.Now;
        [ExcelDisplay(ColumnNo = 15, Name = "AccountingTime")]
        public DateTime AccountingTime { get; set; }
        [ExcelDisplay(ColumnNo = 16, Name = "Country")]
        public string Country { get; set; }
        [ExcelDisplay(ColumnNo = 17, Name = "City")]
        public string City { get; set; }
        [ExcelDisplay(ColumnNo = 18, Name = "PassportSubmissionTime")]
        public DateTime PassportSubmissionTime { get; set; } = DateTime.Now;
        public string TestEndPassportDate { get; set; }
        public bool IsDeleted { get; set; }


        public override bool IsValid(out string message)
        {
            var t = BirthDate;

            if(string.IsNullOrWhiteSpace(Name))
            {
                message=ValidationHelper.GetRequiredMessage("Name");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Surname))
            {
                message = ValidationHelper.GetRequiredMessage("Surname");
                return false;
            }


            if (string.IsNullOrWhiteSpace(FatherName))
            {
                message = ValidationHelper.GetRequiredMessage("Father name");
                return false;
            }

            if (string.IsNullOrWhiteSpace(FIN))
            {
                message = ValidationHelper.GetRequiredMessage("FIN");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Seriya))
            {
                message = ValidationHelper.GetRequiredMessage("Seriya");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Phone))
            {
                message = ValidationHelper.GetRequiredMessage("Phone");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Adress))
            {
                message = ValidationHelper.GetRequiredMessage("Adress");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Studies))
            {
                message = ValidationHelper.GetRequiredMessage("Studies");
                return false;
            }


            if (string.IsNullOrWhiteSpace(City))
            {
                message = ValidationHelper.GetRequiredMessage("City");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Citizenship))
            {
                message = ValidationHelper.GetRequiredMessage("Citizenship");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Email))
            {
                message = ValidationHelper.GetRequiredMessage("Email");
                return false;
            }

            if (string.IsNullOrWhiteSpace(PlaceOfBirth))
            {
                message = ValidationHelper.GetRequiredMessage("PlaceOfBirth");
                return false;
            }


            /*if (string.IsNullOrWhiteSpace(BirthDate))
            {
                message = ValidationHelper.GetRequiredMessage("BirthDate");
                return false;
            }*/

            if (string.IsNullOrWhiteSpace(Country))
            {
                message = ValidationHelper.GetRequiredMessage("Country");
                return false;
            }


            message = string.Empty;
            return true;
        }

        public override object Clone()
        {
            var clientModel = new ClientModel()
            {
                Id = Id,
                NO = NO,
                Name=Name,
                Surname=Surname,
                FatherName=FatherName,
                FIN=FIN,
                Seriya=Seriya,
                Phone=Phone,
                Adress=Adress,
                IsDeleted = IsDeleted,
                PlaceOfBirth= PlaceOfBirth,
                Citizenship= Citizenship,
                Studies= Studies,
                Email= Email,
                PassportEndTime= PassportEndTime,
                BirthDate= BirthDate,
                Country= Country,
                City= City,
                PassportSubmissionTime= PassportSubmissionTime,
                AccountingTime = AccountingTime,
            };

            if (Card != null)
            {
                Card.Client = null;

                clientModel.Card = Card?.Clone() as CardModel;
                clientModel.Card.Client = clientModel;

                Card.Client = this;
            }

            return clientModel;
        }

        public override string ToString()
        {
            return $"{Name}";
        }

        public override string ToExcelString()
        {
            return $"{Name}";
        }
    }
}
