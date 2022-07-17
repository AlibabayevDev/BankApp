using BankApp.AdminPanel.Attributes;
using BankApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Model
{
    public class CreditModel : BaseModel
    {
        [ExcelDisplay(ColumnNo = 1, Name = "Name")]
        public ClientModel Client { get; set; } = new ClientModel();

        [ExcelDisplay(ColumnNo = 2, Name = "Branch")]
        public BranchModel Branch { get; set; } = new BranchModel();

        [ExcelDisplay(ColumnNo = 3, Name = "Amount")]
        public double Amount { get; set; }

        [ExcelDisplay(ColumnNo = 4, Name = "Credit percent")]
        public double CreditPercent { get; set; }

        [ExcelDisplay(ColumnNo = 5, Name = "Return amount")]
        public double AmountReturn { get; set; }

        [ExcelDisplay(ColumnNo = 6, Name = "Give date")]
        public DateTime GiveDate { get; set; } = DateTime.Now;

        [ExcelDisplay(ColumnNo = 7, Name = "Return date")]
        public DateTime ReturnDate { get; set; } = DateTime.Now;
        public int BranchId { get; set; }

        public User Cretor { get; set; }


        public override bool IsValid(out string message)
        {
            if (string.IsNullOrWhiteSpace(Amount.ToString()))
            {
                message = ValidationHelper.GetRequiredMessage("Amount");
                return false;
            }

            if (string.IsNullOrWhiteSpace(CreditPercent.ToString()))
            {
                message = ValidationHelper.GetRequiredMessage("Credit percent");
                return false;
            }


            if (string.IsNullOrWhiteSpace(AmountReturn.ToString()))
            {
                message = ValidationHelper.GetRequiredMessage("Amount return");
                return false;
            }

            if (string.IsNullOrWhiteSpace(GiveDate.ToString()))
            {
                message = ValidationHelper.GetRequiredMessage("Give date");
                return false;
            }


            if (string.IsNullOrWhiteSpace(ReturnDate.ToString()))
            {
                message = ValidationHelper.GetRequiredMessage("Give date");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Client.ToString()))
            {
                message = ValidationHelper.GetRequiredMessage("Client name");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Branch.ToString()))
            {
                message = ValidationHelper.GetRequiredMessage("Branch name");
                return false;
            }

            message = string.Empty;
            return true;
        }


        public override object Clone()
        {
            return new CreditModel()
            {
                Id = Id,
                Amount = Amount,
                CreditPercent = CreditPercent,
                AmountReturn = AmountReturn,
                GiveDate = GiveDate,
                ReturnDate = ReturnDate,
                BranchId = BranchId,
                NO = NO,
            };
        }

        public override string ToExcelString()
        {
            return $"{Amount}";
        }
    }

}
