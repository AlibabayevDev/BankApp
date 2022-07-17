using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel
{
    public class ValidationHelper
    {
        public static string GetRequiredMessage(string propertyName)
        {
            return $"{propertyName} is required";
        }

        public static string GetRequiredLength(string propertyName, int length)
        {
            return $"{propertyName} must contain {length} characters";     
        }
    }
}
