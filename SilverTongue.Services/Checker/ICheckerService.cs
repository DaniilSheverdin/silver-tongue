using System;
using System.Collections.Generic;

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
        ServiceResponse<List<Data.Models.SpellCheck>> Check(string word, int id);
    }
}
