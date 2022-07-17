using BankApp.AdminPanel.Commands.ClientCommand.ClientControlCommands;
using BankApp.AdminPanel.DataContext;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.AdminPanel.ViewModel.Controls.ClientControls;
using BankApp.AdminPanel.ViewModel.Controls.ClietnControls;
using BankApp.AdminPanel.Views.Controls.ClientsControls;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Commands.ClientCommand.Commands
{
    public class BackMainClientControlCommand : BaseCommand
    {
        public readonly RestoreClientControlViewModel viewModel;
        public BackMainClientControlCommand(RestoreClientControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("az-AZ");
            viewModel.CenterGrid.Children.Clear();

            MainClientControl mainClientControl = new MainClientControl();
            MainClientControlViewModel mainClientControlViewModel = new MainClientControlViewModel(Kernel.DB);
            mainClientControlViewModel.CenterGridMainClient = mainClientControl.CenterGridMainClient;

            mainClientControlViewModel.AllValues = viewModel.DataProvider.GetClient();


            mainClientControlViewModel.CurrentValue = viewModel.CurrentValue;
            mainClientControlViewModel.ErrorDialog = mainClientControl.ErrorDialog;

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            var rez = cultures.Select(cult => (new RegionInfo(cult.LCID)).DisplayName).Distinct().OrderBy(q => q).ToList();

            string items = string.Join(Environment.NewLine, rez);

            for (int i = 0; i < rez.Count; i++)
            {
                mainClientControl.PlaceOfBirth.Items.Add(rez[i]);
                mainClientControl.Citizenship.Items.Add(rez[i]);
                mainClientControl.Country.Items.Add(rez[i]);
            }

            mainClientControl.DataContext = mainClientControlViewModel;

            mainClientControlViewModel.Initialize();
            viewModel.CenterGrid.Children.Add(mainClientControl);
        }

    }
}
