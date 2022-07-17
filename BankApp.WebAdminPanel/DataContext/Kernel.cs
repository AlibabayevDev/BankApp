using BankApp.Core.DataAccess.Abstract;
using BankApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.DataContext
{
    public static class Kernel
    {
        public static IUnitOfWork DB { get; set; }
        public static User CurrentUser { get; set; }
    }
}
