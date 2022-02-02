using System;
using System.Collections.Generic;
using System.Text;

namespace SilverTongue.Services.Dictionary
{
   public interface IDictionaryService
   {
        List<Data.Models.UsersDitctionary> GetByUserId(int id);//получить записи пользователя
        ServiceResponse<Data.Models.UsersDitctionary> AddNote(Data.Models.UsersDitctionary note);//добавить запись
        ServiceResponse<Data.Models.UsersDitctionary> DeleteNote(int id);//удалить запись
    }
}
