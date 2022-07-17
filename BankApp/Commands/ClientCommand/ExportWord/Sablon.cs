using BankApp.AdminPanel.ViewModel.Controls.ClietnControls;
using BankApp.Commands;
using DevExpress.Utils.CommonDialogs.Internal;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Word = Microsoft.Office.Interop.Word;


namespace BankApp.AdminPanel.Commands.ClientCommand.ExportWord
{
    public class Sablon : BaseCommand
    {
        private readonly MainClientControlViewModel viewModel;
        public Sablon(MainClientControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
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
                { "<PassportSubmissionTime>",viewModel.CurrentValue.PassportSubmissionTime.ToString("dd.MM.yyyy")},
                { "<Studies>",viewModel.CurrentValue.Studies },
            };

            helper.Process(items);

        }


        public class ExportToWord
        {

            private FileInfo _fileInfo;

            public ExportToWord(string fileName)
            {
                if (File.Exists(fileName))
                {
                    _fileInfo = new FileInfo(fileName);
                }
                else
                {
                    throw new ArgumentException("File not found");
                }
            }

            internal bool Process(Dictionary<string, string> items)
            {
                Word.Application app = null;
                try
                {
                    app = new Word.Application();

                    string newFileName = Path.Combine(_fileInfo.DirectoryName, DateTime.Now.ToString("yyyyMMdd HHmmss ") + _fileInfo.Name);
                    File.Copy(_fileInfo.FullName, newFileName);

                    Object file = newFileName;

                    Object missing = Type.Missing;

                    app.Documents.Open(file);

                    foreach (var item in items)
                    {
                        Word.Find find = app.Selection.Find;
                        find.Text = item.Key;
                        find.Replacement.Text = item.Value;

                        Object wrap = Word.WdFindWrap.wdFindContinue;
                        Object replace = Word.WdReplace.wdReplaceAll;

                        find.Execute(FindText: Type.Missing,
                            MatchCase: false,
                            MatchWholeWord: false,
                            MatchWildcards: false,
                            MatchSoundsLike: missing,
                            MatchAllWordForms: false,
                            Forward: true,
                            Wrap: wrap,
                            Format: false,
                            ReplaceWith: missing, Replace: replace);
                    }

                    app.ActiveDocument.Save();

                    app.Visible = true;
                    app.ActiveDocument.PrintPreview();
                    return true;
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }


                return false;
            }

            internal List<string> ReadText()
            {
                Word.Application app = null;
                try
                {
                    app = new Word.Application();
                    Object file = _fileInfo.FullName;

                    Object missing = Type.Missing;

                    Word.Document doc = app.Documents.Open(file);
                    var list = new List<string>();

                    foreach (Word.Paragraph paragraph in doc.Paragraphs)
                    {
                        list.Add(paragraph.Range.Text);
                    }

                    app.ActiveDocument.Close();

                    return list;
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally
                {
                    if (app != null)
                    {
                        app.Quit();
                    }
                }

                return null;
            }
        }
    }
}
