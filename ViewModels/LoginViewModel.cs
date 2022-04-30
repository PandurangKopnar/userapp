using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.ComponentModel.DataAnnotations;
using UserApp.Models;
using UserApp.Models.Login;
using UserApp.Services;

namespace UserApp.ViewModels
{
    public class LoginViewModel
    {   
        public async Task<User> ValidateUser(LoginModel loginModel)
        {
            int result = 0;
            User user1=null;
            HttpService service = new HttpService();
            User user= await service.Get<User>(String.Format(@"https://localhost:7235/api/User/{0}/{1}",loginModel.Username,loginModel.Password));
            if (user != null)
            {
                user1 = user;
                return user1;
            }
                
            result = 1;
            return user1;
        }
    }
}
