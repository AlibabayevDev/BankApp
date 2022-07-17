using BankApp.AdminPanel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Model
{
    public abstract class BaseModel : ICloneable
    {
        [ExcelIgnore]
        public int Id { get; set; }

       // [ExcelDisplay(ColumnNo = 0,Name = "No")]
        public int NO { get; set; }

        public abstract bool IsValid(out string message);

        public abstract object Clone();
        public abstract string ToExcelString();
      
    }
}
