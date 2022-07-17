using Microsoft.AspNetCore.Mvc.Rendering; 

namespace BankApp.WebAdminPanel.Models.Client
{
    public class SaveClientViewModel
    {
        public SelectList ClientList { get; set; }
        public ClientModel ClientModel { get; set; }
    }
}
