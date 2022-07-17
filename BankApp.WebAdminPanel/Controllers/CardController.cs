using BankApp.AdminPanel.Mappers;
using BankApp.AdminPanel.Utils;
using BankApp.Core.DataAccess.Abstract;
using BankApp.Core.Domain.Entities;
using BankApp.WebAdminPanel.Mappers;
using BankApp.WebAdminPanel.Models.Card;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankApp.WebAdminPanel.Controllers
{
    [Authorize(Roles = "A,SA")]
    public class CardController : Controller
    {
        private readonly IUnitOfWork db;

        public CardController(IUnitOfWork db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cards = db.CardRepository.Get();

            CardMapper cardMapper = new CardMapper();

            List<CardModel> cardModels = new List<CardModel>();

            for (int i = 0; i < cards.Count; i++)
            {
                var branch = cards[i];
                var branchModel = cardMapper.Map(branch);

                branchModel.NO = i + 1;
                cardModels.Add(branchModel);
            }

            CardViewModel viewModel = new CardViewModel()
            {
                Cards = cardModels
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Save(int id)
        {
            SaveCardViewModel viewModel = new SaveCardViewModel();

            var cards = db.ClientRepository.Get();

            viewModel.CardList = new SelectList(cards, "Id", "Name");

            if (id != 0)
            {
                var cardMapper = new CardMapper();
                var card = db.CardRepository.Get(id);
                var cardModel = cardMapper.Map(card);
                viewModel.Card = cardModel;
            }

            return PartialView(viewModel);
        }
   
        [HttpPost]
        public IActionResult Save(SaveCardViewModel viewModel)   
        {
            try
            {
                //if (ModelState.IsValid == false)
                //{
                //    var errors = ModelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage).ToList();
                //    var errorMessage = errors.Aggregate((message, value) =>
                //    {
                //        if (message.Length == 0)
                //            return value;

                //        return message + ", " + value;
                //    });

                //    TempData["Message"] = errorMessage;
                //    return RedirectToAction("Index");
                //}

                var model = viewModel.Card;
                var cardMapper = new CardMapper();
                var card = cardMapper.Map(model);

                if (model.Id != 0)
                {
                    db.CardRepository.Update(card);
                }
                else
                {
                    db.CardRepository.Insert(card);
                }

                TempData["Message"] = "Operation successfully";
            }
            catch(Exception ex)
            {       
                Logger.Log(ex);
                TempData["Message"] = "Operation unsuccessfully";
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Delete(CardViewModel viewModel)
        {
            var deletedId = viewModel.Deleted.Id;

            var card = db.CardRepository.Get(deletedId);

            card.IsDeleted = true;

            db.CardRepository.Update(card);

            TempData["Message"] = "Operation successfully";

            return RedirectToAction("Index");
        }
    }
}
