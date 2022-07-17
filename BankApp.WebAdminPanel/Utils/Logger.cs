using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace BankApp.AdminPanel.Utils
{
    public static class Logger
    {
        public static void Log(Exception exception)
        {
            Task.Run(() =>
            {
                if (Directory.Exists(Constants.LogFileFolder) == false)
                {
                    Directory.CreateDirectory(Constants.LogFileFolder);
                }

                using (var writer = File.AppendText(Constants.LogFilePath))
                {
                    writer.WriteLine(DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine(exception.ToString());
                    writer.WriteLine();
                    writer.WriteLine();
                }
            });
        }



        public static void Log(TimeSpan date)
        {
            Task.Run(() =>
            {
                if (Directory.Exists(Constants.LogFileFolder) == false)
                {
                    Directory.CreateDirectory(Constants.LogFileFolder);
                }

                using (var writer = File.AppendText(Constants.EnterFilePath))
                {
                    writer.WriteLine(DateTime.Now.ToString(CultureInfo.InvariantCulture));
                }
            });
        }
    }
}
