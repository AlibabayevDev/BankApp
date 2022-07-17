using BankApp.Core.DataAccess.Abstract;
using BankApp.WebAdminPanel.Models.Employee;
using BankApp.WebCore.Mappers;
using BankApp.WebCore.Model;
using BankApp.WebCore.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        //[Route("test")]
        public IActionResult Get()
        {
            try
            {
                var employees = employeeService.GetAll();


                return Ok(employees);
            }
            
            catch
            {
                return BadRequest("Unknown error");
            }
        }

        [HttpPost]
        public IActionResult Posty(EmployeeModel employeeModel)
        {
            return Ok("Tosu Zenglinski");
        }

        [HttpDelete]

        public IActionResult Delete(EmployeeModel employeeModel)
        {
            return Ok();
        }
    }
}
