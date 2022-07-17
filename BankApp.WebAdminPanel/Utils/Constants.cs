using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel
{
    class Constants
    {
        public const string DateFormat = "dd.MM.yyyy";
        public const string OperationSuccessMessage = "Operation completed successfully";
        public const string OperationFaultMessage = "Operation completed unsuccessfully";
        public const string ErrorMessage = "Unknown error occured.";
        public const string SureDeleteMessage = "Are you sure you want to delete?";
        public const string SureRestoreMessage = "Are you sure you want to restore?";

        public static string LogFileFolder = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\BankApplication\";
        public static string LogFilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\BankApplication\log.txt";
    
        public static string EnterFilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\BankApplication\Login.txt";
    }
}
