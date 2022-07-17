using BankApp.AdminPanel.Attributes;
using BankApp.AdminPanel.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Model
{
    public class EmployeeModel : BaseModel
    {
      //  public int IdLogin { get; set; }
   //     public int BranchId { get; set; }

        

        [ExcelDisplay(ColumnNo = 1, Name = "Firtname")]
        public string FirstName { get; set; }

        [ExcelDisplay(ColumnNo = 2, Name = "Lastname")]
        public string Surname { get; set; }

        [ExcelDisplay(ColumnNo = 3, Name = "Speciality")]
        public string Speciality { get; set; }

        [ExcelDisplay(ColumnNo = 4, Name = "Salary")]
        public decimal Salary { get; set; }

        [ExcelDisplay(ColumnNo = 5, Name = "Address")]
        public string Address { get; set; }

        [ExcelDisplay(ColumnNo = 6, Name = "Phone")]
        public string Phone { get; set; }

        [ExcelDisplay(ColumnNo = 7, Name = "Branch")]
        public BranchModel Branch { get; set; } = new BranchModel();

        //  public bool IsDeleted { get; set; }

        public override object Clone()
        {
            return new EmployeeModel()
            {
                Id = Id,
                Branch = Branch?.Clone() as BranchModel,
           //     BranchId = BranchId,
                FirstName = FirstName,
                Surname = Surname,
                Speciality = Speciality,
                Salary = Salary,
                Address = Address,
                Phone = Phone,
            //    IsDeleted = IsDeleted,
            };
        }

        public override bool IsValid(out string message)
        {
            //if (string.IsNullOrWhiteSpace(IdLogin.ToString()))
            //{
            //    message = ValidationHelper.GetRequireMessage("IdLogin");
            //    return false;
            //}

            //if (string.IsNullOrWhiteSpace(BranchId.ToString()))
            //{
            //    message = ValidationHelper.GetRequireMessage("IdBranch");
            //    return false;
            //}


            if (string.IsNullOrWhiteSpace(FirstName))
            {
                message = ValidationHelper.GetRequiredMessage("Name");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Surname))
            {
                message = ValidationHelper.GetRequiredMessage("Surname");
                return false;
            }


            if (string.IsNullOrWhiteSpace(Speciality))
            {
                message = ValidationHelper.GetRequiredMessage("Speciality");
                return false;
            }


            if (string.IsNullOrWhiteSpace(Salary.ToString()))
            {
                message = ValidationHelper.GetRequiredMessage("Salary");
                return false;
            }


            if (string.IsNullOrWhiteSpace(Address))
            {
                message = ValidationHelper.GetRequiredMessage("Address");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Phone))
            {
                message = ValidationHelper.GetRequiredMessage("Phone");
                return false;
            }

            message = string.Empty;
            return true;
        }

        public override string ToExcelString()
        {
            return $"{FirstName} {Surname} {Speciality}";
        }
    }
}
