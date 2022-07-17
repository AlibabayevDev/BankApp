using BankApp.Core.DataAccess.Abstract;
using BankApp.WebAdminPanel.Mappers;
using BankApp.WebAdminPanel.Models.Employee;
using BankApp.WebCore.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankApp.WebAdminPanel.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService db;

        public EmployeeController(IEmployeeService db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var employees = db.GetAll();


            EmployeeViewModel viewModel = new EmployeeViewModel()
            {
                Employee = employees
            };

            if (TempData["Message"] != null)
            {
                viewModel.Message = TempData["Message"].ToString();
            }
            return View(viewModel);

        }

        /*[HttpGet]
        public IActionResult Save(int id)
        {
            SaveEmployeeViewModel viewModel = new SaveEmployeeViewModel();

            var clients = db.BranchesRepository.Get();

            viewModel.BranchList = new SelectList(clients, "Id", "BranchName");

            if (id != 0)
            {
                var employeeMapper = new EmployeeMapper();
                var employee = db.EmployeeRepository.Get(id);
                var employeeModel = employeeMapper.Map(employee);
                viewModel.Employee = employeeModel;
            }

            return PartialView(viewModel);
        }

        [HttpPost]
        public IActionResult Save(SaveEmployeeViewModel viewModel)
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

                var model = viewModel.Employee;

                var bankMapper = new EmployeeMapper();

                var bank = bankMapper.Map(model);

                if (model.Id != 0)
                {
                    db.EmployeeRepository.Update(bank);
                }
                else
                {
                    db.EmployeeRepository.Insert(bank);
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
        */
    }
}
