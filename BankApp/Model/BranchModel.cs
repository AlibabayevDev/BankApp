using BankApp.AdminPanel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Model
{
    public class BranchModel : BaseModel
    {
        [ExcelDisplay(ColumnNo = 1, Name = "Name")]
        public string BranchName { get; set; }

        [ExcelDisplay(ColumnNo = 2, Name = "Adress")]
        public string Adress { get; set; }

        [ExcelDisplay(ColumnNo = 3, Name = "Phone")]
        public string Phone { get; set; }

        [ExcelDisplay(ColumnNo = 4, Name = "BeginWorkTime")]
        public string BeginWorkTime { get; set; }

        [ExcelDisplay(ColumnNo = 5, Name = "EndWorkTime")]
        public string EndWorkTime { get; set; }

        [ExcelDisplay(ColumnNo = 6, Name = "CountWorkers")]
        public int CountWorkers { get; set; }

     //   public bool IsDeleted { get; set; }

        public override object Clone()
        {
            return new BranchModel()
            {
                Id = Id,
                BranchName = BranchName,
                Adress = Adress,
                Phone = Phone,
                BeginWorkTime = BeginWorkTime,
                EndWorkTime = EndWorkTime,
                CountWorkers = CountWorkers
            };

        }

        public override bool IsValid(out string message)
        {
            if (string.IsNullOrWhiteSpace(BranchName))
            {
                message = ValidationHelper.GetRequiredMessage("Name");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Adress))
            {
                message = ValidationHelper.GetRequiredMessage("Adress");
                return false;
            }

            if (string.IsNullOrWhiteSpace(BeginWorkTime))
            {
                message = ValidationHelper.GetRequiredMessage("BeginWorkTime");
                return false;
            }

            if (string.IsNullOrWhiteSpace(EndWorkTime))
            {
                message = ValidationHelper.GetRequiredMessage("EndWorkTime");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Adress))
            {
                message = ValidationHelper.GetRequiredMessage("Adress");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Phone))
            {
                message = ValidationHelper.GetRequiredMessage("Phone");
                return false;
            }

            if (CountWorkers==0)
            {
                message = ValidationHelper.GetRequiredMessage("CountWorkers");
                return false;
            }
            message = string.Empty;
            return true;
        }

        public override string ToString()
        {
            return $"{BranchName}";
        }

        public override string ToExcelString()
        {
            return $"{BranchName}";
        }
    }
}
