using UserApp.Models;
using UserApp.Services;

namespace UserApp.ViewModels
{
    public class UserViewModel
    {
        public async Task<List<User>> GetUser()
        {            
            HttpService service = new HttpService();
            List<User> users = await service.Get<List<User>>(String.Format(@"https://localhost:7235/api/User"));            
            return users;
        }
    }
}
