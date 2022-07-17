using BankApp.AdminPanel.Commands.ClientCommand.ExportWord;
using BankApp.AdminPanel.Enums;
using BankApp.AdminPanel.Mappers;
using BankApp.AdminPanel.ViewModel.Controls;
using BankApp.AdminPanel.ViewModel.Controls.ClietnControls;
using BankApp.AdminPanel.Views.Windows;
using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static BankApp.AdminPanel.Commands.ClientCommand.ExportWord.Sablon;
using Word = Microsoft.Office.Interop.Word;

namespace BankApp.AdminPanel.Commands.ClientCommand
{
    public class SaveCommand : BaseCommand
    {
        private readonly MainClientControlViewModel viewModel;
        public SaveCommand(MainClientControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            Save();
        }

        private void Save()
        {
            if(viewModel.CurrentValue.IsValid(out string message) == false)
            {
                viewModel.Message = message;
                DoAnimation(viewModel.ErrorDialog);
                return;
            }
            ClientMapper bankMapper = new ClientMapper();

            var bank = bankMapper.Map(viewModel.CurrentValue);


            if (bank.Id != 0)
            {
                viewModel.DB.ClientRepository.Update(bank);
                MessageBox.Show("Successfully edit");
            }
            else
            {
                viewModel.DB.ClientRepository.Insert(bank);
                var helper = new ExportToWord("Sablon.doc");

                var items = new Dictionary<string, string>
                {
                    { "<Name>" , viewModel.CurrentValue.Name },
                    { "<Surname>" , viewModel.CurrentValue.Surname },
                    { "<FatherName>" , viewModel.CurrentValue.FatherName },
                    { "<FIN>" , viewModel.CurrentValue.FIN },
                    { "<BirthDate>" , viewModel.CurrentValue.BirthDate.ToString("dd.MM.yyyy")},
                    { "<Phone>" , viewModel.CurrentValue.Phone },
                    { "<Citizenship>" , viewModel.CurrentValue.Citizenship },
                    { "<Seriya>" , viewModel.CurrentValue.Seriya },
                    { "<PassportEndTime>" , viewModel.CurrentValue.PassportEndTime.ToString("dd.MM.yyyy")},
                    { "<Adress>" , viewModel.CurrentValue.Adress },
                    { "<Email>" , viewModel.CurrentValue.Email},
                    { "<NowDate>" , DateTime.Now.ToString("dd.MM.yyyy")},
                    { "<PassportSubmissionTime>",viewModel.CurrentValue.PassportSubmissionTime.ToString("dd.MM.yyyy") },
                    { "<Studies>",viewModel.CurrentValue.Studies },
                };
                helper.Process(items);
                MessageBox.Show("Successfully added");
            }

            viewModel.Message = Constants.OperationSuccessMessage;

            DoAnimation(viewModel.ErrorDialog);

            viewModel.AllValues = viewModel.DataProvider.GetClient();

            viewModel.Initialize();
            viewModel.CurrentSituation = (int)ClientSituation.NORMAL;
        }
    }
}
