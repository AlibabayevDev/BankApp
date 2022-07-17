using BankApp.WebAdminPanel.Models.Client;

namespace BankApp.WebAdminPanel.Models.Card
{
    public class CardModel : BaseModel
    {
        public int ClientId { get; set; }
        public ClientModel Client { get; set; }
        public string? TypeCard { get; set; }
        public string CardNumber { get; set; }
        public DateTime EndDate { get; set; } =  DateTime.Now;
    }
}
