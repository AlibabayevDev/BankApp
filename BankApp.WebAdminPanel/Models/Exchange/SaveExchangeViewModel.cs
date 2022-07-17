using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankApp.WebAdminPanel.Models.Exchange
{
    public class SaveExchangeViewModel
    {
        public SelectList ExchangeList { get; set; }
        public ExchangeModel Exchange { get; set; }
    }
}
