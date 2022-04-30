using UserApp.Models;
using UserApp.Models.Login;
using UserApp.Services;

namespace UserApp.ViewModels
{
    public class RegisterViewModel
    {
        public async Task<int> AddUser(RegisterModel register)
        {
            int result = 0;
           
            HttpService service = new HttpService();
            RegisterModel register1 =await service.Post<RegisterModel>(@"https://localhost:7235/api/User", register);
            

            result = 1;
            return 1;
        }
    }
}
