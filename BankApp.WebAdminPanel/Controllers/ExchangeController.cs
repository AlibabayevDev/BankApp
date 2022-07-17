using BankApp.AdminPanel.DataContext;
using BankApp.AdminPanel.Mappers;
using BankApp.Core.DataAccess.Abstract;
using BankApp.WebAdminPanel.Models.Client;
using BankApp.WebAdminPanel.Models.Exchange;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace BankApp.WebAdminPanel.Controllers
{
    [Authorize(Roles = "A,SA")]

    public class ExchangeController : Controller
    {
        private readonly IUnitOfWork db;

        public ExchangeController(IUnitOfWork db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var employees = db.ExchangeRepository.Get();

            ExchangeMapper employeeBranch = new ExchangeMapper();
            List<ExchangeModel> employeeModels = new List<ExchangeModel>();

            for (int i = 0; i < employees.Count; i++)
            {
                var employee = employees[i];
                var employeeModel = employeeBranch.Map(employee);

                employeeModel.NO = i + 1;
                employeeModels.Add(employeeModel);
            }

            ExchangeViewModel viewModel = new ExchangeViewModel()
            {
                Exchanges = employeeModels
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
            id = 9;
            SaveExchangeViewModel viewModel = new SaveExchangeViewModel();

            var clients = db.ClientRepository.Get();

            viewModel.ExchangeList = new SelectList(clients, "Id", "Name");

            if (id != 0)
            {
                var exchangeMapper = new ExchangeMapper();
                var exchange = db.ExchangeRepository.Get(id);
                var exchangeModel = exchangeMapper.Map(exchange);
                viewModel.Exchange = exchangeModel;
            }

            return PartialView(viewModel);
        }

        [HttpPost]
        public IActionResult Save(SaveExchangeViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    var errors = ModelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage).ToList();
                    var errorMessage = errors.Aggregate((message, value) =>
                    {
                        if (message.Length == 0)
                            return value;

                        return message + ", " + value;
                    });

                    TempData["Message"] = errorMessage;
                    return RedirectToAction("Index");
                }

                var model = viewModel.Exchange;

                var bankMapper = new ExchangeMapper();

                var bank = bankMapper.Map(model);

                if (model.Id != 0)
                {
                    db.ExchangeRepository.Update(bank);
                }
                else
                {
                    db.ExchangeRepository.Insert(bank);
                }

                TempData["Message"] = "Operation successfully";
            }
            catch (Exception exc)
            {
                // log exception here

                TempData["Message"] = "Operation unsuccessfully";
            }

            return RedirectToAction("Index");
        }
    }
    }


        



