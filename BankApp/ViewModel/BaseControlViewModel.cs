using BankApp.AdminPanel.Commands;
using BankApp.AdminPanel.Commands.CardCommand;
using BankApp.AdminPanel.Commands.ExchangeCommand;
using BankApp.AdminPanel.DataContext;
using BankApp.AdminPanel.Enums;
using BankApp.AdminPanel.Model;
using BankApp.AdminPanel.Views.Components;
using BankApp.Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace BankApp.AdminPanel.ViewModel
{
    public abstract class BaseControlViewModel<T> : BaseViewModel where T : BaseModel,new()
    {
        public IUnitOfWork DB { get; }
        public DataProvider DataProvider { get; }
        public BaseControlViewModel(IUnitOfWork db)
        {
            DB = db;
            DataProvider = new DataProvider(db);
        }

        public void Initialize()
        {
            Values = new ObservableCollection<T>(AllValues);
            CurrentSituation = (int)Situations.NORMAL;
        }

        public abstract string Header { get; }
        public RejectCommand<T>  Reject => new RejectCommand<T>(this);
        public ExcelExportCommand<T> ExportExcel => new ExcelExportCommand<T>(this);

        public virtual void OnCurrentValueChange()
        {

        }

        #region 

        private byte currentSituation = (byte)Situations.NORMAL;

        public byte CurrentSituation
        {
            get
            {
                return currentSituation;
            }
            set
            {
                currentSituation = value;
                OnPropertyChanged(nameof(CurrentSituation));
            }
        }

        private string message;
        public string Message
        {
            get => message;
            set
            {
                message = value;
                OnPropertyChanged(nameof(Message));
                OnPropertyChanged(nameof(TextColor));
            }
        }
        #endregion 

        public Brush TextColor => Message == Constants.OperationSuccessMessage ? Brushes.Green : Brushes.Red;
        public ErrorDialog ErrorDialog { get; set; }

        private T selectedValue;

        public T SelectedValue
        {
            get
            {
                return selectedValue;
            }
            set
            {
                selectedValue = value;
                CurrentValue = (T)SelectedValue?.Clone();
                CurrentSituation = SelectedValue != null ? (byte)Situations.SELECTED : (byte)Situations.NORMAL;
                OnCurrentValueChange();
                OnPropertyChanged(nameof(SelectedValue));
            }

        }

        private T currentValue = new T();
        public T CurrentValue
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = value;
                OnPropertyChanged(nameof(CurrentValue));
            }
        }

        public List<T> AllValues { get; set; }

        private ObservableCollection<T> values;
        public ObservableCollection<T> Values
        {
            get
            {
                return values;
            }
            set
            {
                values = value;
                OnPropertyChanged(nameof(Values));
            }
        }
    }
}
