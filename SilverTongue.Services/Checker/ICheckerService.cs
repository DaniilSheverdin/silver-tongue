using SilverTongue.Data.Models;
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
        ServiceResponse<Tuple<List<SpellCheck>, Check>> Check(string word, int id);
    }
}
