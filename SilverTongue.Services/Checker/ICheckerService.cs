using System;
using System.Collections.Generic;
using System.Text;

namespace SilverTongue.Services.Checker
{
    public interface ICheckerService
    {
        /// <summary>
        /// Проверка грамматики и орфографии
        /// </summary>
        /// <param name="word"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        ServiceResponse<Tuple<Data.Models.Check,List<Data.Models.SpellCheck>>> Check(string word, int id);
    }
}
