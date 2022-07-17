using BankApp.Core.Domain.Entities;
using BankApp.Core.Utils;
using BankApp.Domain.Entities;
using BankApp.WebAdminPanel.Models.Account;
using BankApp.WebApi.Mapper;
using BankApp.WebApi.Model;
using BankApp.WebCore.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BankApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModel loginModel)
        {
            var user = userManager.FindByNameAsync(loginModel.Email).Result;

            if (user == null)
                return Content("Username or password is incorrect");

            var signInResult = signInManager.PasswordSignInAsync(user, loginModel.Password, true, false).Result;

            if (signInResult.Succeeded == false)
                return BadRequest("Username or password is incorrect");

            string token = GenerateJwtToken(user);

            return Ok(new LoginResponseModel()
            {
                Email = loginModel.Email,
                Token = token
            });

        }


        [HttpPost]
        [Route("Regist")]
        public IActionResult Regist(Regist regist)
        {
            //RegistMapper registMapper=new RegistMapper();

            //var registModel = registMapper.Map(regist);

            User user = new User();

            user.Username = regist.email;
            user.PasswordHash = SecurityUtil.ComputeSha256Hash(regist.password);

            var userRegist = userManager.CreateAsync(user).Result;

            string token = GenerateJwtToken(user);

            return Ok(new LoginResponseModel()
            {
                Email = regist.email,
                Token = token
            });
        }

        #region private logic

        private string GenerateJwtToken(Core.Domain.Entities.User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            byte[] key = Encoding.ASCII.GetBytes("xecretKeywqejane");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Username),
                }),
                Expires = DateTime.Now.AddDays(15), //Token expires after 15 days
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        #endregion
    }
}
