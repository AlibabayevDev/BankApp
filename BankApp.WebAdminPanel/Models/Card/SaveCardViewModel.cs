using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankApp.WebAdminPanel.Models.Card
{
    public class SaveCardViewModel
    {
        public SelectList CardList { get; set; }

        public CardModel Card { get; set; }
    }
}
