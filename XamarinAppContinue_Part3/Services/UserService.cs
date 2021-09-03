using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinAppContinue_Part3.Models;

namespace XamarinAppContinue_Part3.Services
{
    class UserService : IUserService
    {
        async public Task<bool> checkLogin(string userName, string password)
        {
            try
            {
                string base_url = "http://10.0.2.2:5000/User/";
                if (Device.RuntimePlatform != Device.Android)
                {
                    base_url = "http://localhost:5000/User/";
                }
                // 10.0.2.2
                string url = base_url + userName + "/" + password;
                HttpClient client = new HttpClient();
                HttpResponseMessage respone = await client.GetAsync(url);
                return respone.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        async public Task<bool> CreateAccount(UserModel user)
        {
            try
            {
                string base_url = "http://10.0.2.2:5000/User/";

                if (Device.RuntimePlatform != Device.Android)
                {
                    base_url = "http://localhost:5000/User/";
                }

                UserModel userInput = new UserModel()
                {
                    userName = user.userName,
                    email = user.email,
                    password = user.password,
                    passwordConfirm = user.passwordConfirm
                };
                string jsonData = JsonConvert.SerializeObject(userInput);

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                HttpResponseMessage respone = await client.PostAsync(base_url, content);

                return respone.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
    
}
