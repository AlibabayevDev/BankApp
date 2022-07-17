using BankApp.AdminPanel.DataContext;
using BankApp.AdminPanel.ViewModel;
using BankApp.Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankApp.AdminPanel.ViewModels
{
    public abstract class BaseWindowViewModel : BaseViewModel
    {
        public IUnitOfWork DB { get; }
        public DataProvider DataProvider { get; }
        public Window Window { get; }

        public BaseWindowViewModel(IUnitOfWork db, Window window)
        {
            DB = db;
            DataProvider = new DataProvider(db);
            Window = window;
        }
    }
}
