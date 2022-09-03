using BankApp.AdminPanel;
using BankApp.AdminPanel.DataContext;
using BankApp.AdminPanel.Utils;
using BankApp.AdminPanel.Views.Windows;
using BankApp.Core.Factory;
using BankApp.ViewModel;
using BankApp.Views.Windows;
using System;
using System.IO;
using System.Windows;
using System.Windows.Threading;

namespace BankApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Dispatcher.UnhandledException += HandleException;

            string connectionString = "Data Source=LAPTOP-8TIN9OH7;Initial Catalog=db_a8537b_bank;Integrated Security=true;";

            /*string path = @"C:\Users\Predator\Desktop\C#\test.txt";
            if (File.Exists(path))
            {
                connectionString = File.ReadAllText(path);
            }
            else
            {
                Console.Write("Vvodite danniye dlya");
                string connectText = Console.ReadLine();
                string path2 = @"C:\Users\Predator\Desktop\test2.txt";

                File.AppendAllText(path2, connectText);
            }*/



            Kernel.DB = DbFactory.Create(connectionString);

            LoginWindow loginWindow = new LoginWindow();
            LoginViewModel loginViewModel = new LoginViewModel(loginWindow, Kernel.DB);


            // MenuWindow menuWindow = new MenuWindow();
            //MenuViewModel menuViewWindow = new MenuViewModel(Kernel.DB,menuWindow);

            //menuWindow.DataContext = menuViewWindow;
            loginWindow.DataContext = loginViewModel;

            loginWindow.Show();
        }

        public void HandleException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Logger.Log(e.Exception);

            UnknownErrorWindow error = new UnknownErrorWindow(SystemParameters.WorkArea.Width * 0.1, SystemParameters.WorkArea.Height * 0.1, Constants.ErrorMessage);
            error.ShowDialog();

            e.Handled = true;
        }
    }
}
