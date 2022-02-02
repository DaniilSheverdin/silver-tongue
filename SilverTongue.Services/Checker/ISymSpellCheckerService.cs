using System;
using System.Collections.Generic;
using System.Text;

namespace SilverTongue.Services.Checker
{
    public interface ISymSpellCheckerService
    {
        /// <summary>
        /// Проверка слова
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        ServiceResponse<Data.Models.SpellCheck>  SpellCheck(SilverTongue.Data.Models.SpellCheckModel model);
    }
}
