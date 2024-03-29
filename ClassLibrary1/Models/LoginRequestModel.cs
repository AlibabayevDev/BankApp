﻿namespace BankApp.WebCore.Models.Account
{
    public class LoginRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; } 
    }

    public class LoginResponseModel
    {
        public string Token { get; set; }
        public string Email { get; set; }
    }
}
