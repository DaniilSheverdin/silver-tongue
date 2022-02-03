using System.Collections.Generic;

namespace SilverTongue.Services.User
{
    public interface IUserService
    {
        Data.Models.Users.User Authenticate(string username, string password);
        IEnumerable<Data.Models.Users.User> GetAll();
        Data.Models.Users.User GetById(int id);
        ServiceResponse<Data.Models.Users.User> Create(Data.Models.Users.User user, string password);
        ServiceResponse<Data.Models.Users.User> Delete(int id);
    }
}
