using System.Collections.Generic;

namespace SilverTongue.Services.Dictionary
{
    public interface IDictionaryService
    {
        List<Data.Models.UsersDitctionary> GetByUserId(int id);//получить записи пользователя
        ServiceResponse<Data.Models.UsersDitctionary> AddNote(Data.Models.UsersDitctionary note, int id);//добавить запись
        ServiceResponse<Data.Models.UsersDitctionary> DeleteNote(string word, int id);//удалить запись
    }
}
