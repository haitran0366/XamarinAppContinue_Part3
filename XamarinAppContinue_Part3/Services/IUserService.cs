using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinAppContinue_Part3.Models;

namespace XamarinAppContinue_Part3.Services
{
    interface IUserService
    {
        Task<bool> checkLogin(string userName, string password);
        Task<bool> CreateAccount(UserModel user);
    }
}
