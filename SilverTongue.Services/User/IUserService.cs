using System;
using System.Collections.Generic;
using System.Text;

namespace SilverTongue.Services.User
{
    public interface IUserService
    {
        List<Data.Models.User> GetAllUser();//получить все записи
        Data.Models.User GetById(int id);//получить записи пользователя
        ServiceResponse<Data.Models.User> AddUser(Data.Models.User note);//добавить запись
        ServiceResponse<Data.Models.User> DeleteNote(int id);//удалить запись

    }
}
