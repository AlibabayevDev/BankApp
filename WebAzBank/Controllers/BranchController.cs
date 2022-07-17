using BankApp.Core.DataAccess.Abstract;
using BankApp.WebAzBank.Mappers;
using BankApp.WebAzBank.Model;
using Microsoft.AspNetCore.Mvc;
using WebAzBank.Models.Client;

namespace BankApp.WebAzBank.Controllers
{
    public class BranchController : Controller
    {
        private readonly IUnitOfWork db;

        public BranchController(IUnitOfWork db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var branches = db.BranchesRepository.Get();

            BranchMapper branchMapper = new BranchMapper();
            List<BranchModel> branchModels = new List<BranchModel>();

            for (int i = 0; i < branches.Count; i++)
            {
                var branch = branches[i];
                var branchModel = branchMapper.Map(branch);

                branchModel.No = i + 1;
                branchModels.Add(branchModel);
            }

            BranchViewModel viewModel = new BranchViewModel()
            {
                Branches = branchModels
            };

            if (TempData["Message"] != null)
            {
                viewModel.Message = TempData["Message"].ToString();
            }
            return View(viewModel);

        }

        [HttpGet]
        public IActionResult Save(int id)
        {
            if(id == 0)
                return PartialView();

            BranchMapper branchMapper = new BranchMapper();

            var branch = db.BranchesRepository.Get(id);

            var branchModel = branchMapper.Map(branch);
            return PartialView(branchModel);
        }

        [HttpPost]
        public IActionResult Save(BranchModel model)
        {
            BranchMapper branchMapper = new BranchMapper();

            var branch = branchMapper.Map(model);

            db.BranchesRepository.Insert(branch);

            TempData["Message"] = "Operation successfully";

            return RedirectToAction("Index");
        }

    }
}
