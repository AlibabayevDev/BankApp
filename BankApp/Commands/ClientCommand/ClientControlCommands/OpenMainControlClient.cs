using BankApp.AdminPanel.DataContext;
using BankApp.AdminPanel.Enums;
using BankApp.AdminPanel.ViewModel;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.AdminPanel.ViewModel.Controls.ClietnControls;
using BankApp.AdminPanel.Views.Controls;
using BankApp.AdminPanel.Views.Controls.ClientsControls;
using BankApp.AdminPanel.Views.Windows;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace BankApp.AdminPanel.Commands.ClientCommand.ClientControlCommands
{
    public class OpenMainControlClient : BaseCommand
    {
        private readonly ClientControlViewModel viewModel;
        public OpenMainControlClient(ClientControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public OpenMainControlClient()
        {
        }

        public void Open()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("az-AZ");
            viewModel.CenterGrid.Children.Clear();

            MainClientControl mainClientControl = new MainClientControl();
            MainClientControlViewModel mainClientControlViewModel = new MainClientControlViewModel(Kernel.DB);
            mainClientControlViewModel.CenterGridMainClient = mainClientControl.CenterGridMainClient;
            mainClientControlViewModel.CardGrid=mainClientControl.CardGrid;


            mainClientControlViewModel.AllValues = viewModel.DataProvider.GetClient();


            mainClientControlViewModel.CurrentValue = viewModel.CurrentValue;
            mainClientControlViewModel.ErrorDialog = mainClientControl.ErrorDialog;

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            var rez = cultures.Select(cult => (new RegionInfo(cult.LCID)).DisplayName).Distinct().OrderBy(q => q).ToList();

            string items = string.Join(Environment.NewLine, rez);

            for (int i = 0; i < 143; i++)
            {
                mainClientControl.PlaceOfBirth.Items.Add(rez[i]);
                mainClientControl.Citizenship.Items.Add(rez[i]);
                mainClientControl.Country.Items.Add(rez[i]);

            }
            mainClientControl.DataContext = mainClientControlViewModel;

            mainClientControlViewModel.Initialize();
            viewModel.CurrentSituation = (int)ClientSituation.NORMAL;
            viewModel.CenterGrid.Children.Add(mainClientControl);
            viewModel.CurrentValue.TestEndPassportDate = viewModel.CurrentValue.PassportEndTime.ToString("dd/MM/yyyy");
        }
        public override void Execute(object parameter)
        {
            if (viewModel.CurrentValue.Id == 0)
            {
                MessageBox.Show("Select Client");
                return;
            }
            Open();
        }
    }
}
