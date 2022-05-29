using SilverTongue.Data.Models;
using SilverTongue.Web.ViewModels;
using System;
using System.Collections.Generic;

namespace SilverTongue.Web.Serialization
{
    public static class CheckMapper
    {
        /// <summary>
        /// Data model to view model
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static CheckViewModel SerializeCheckModel(Tuple<List<SpellCheck>, Check> check_tuple)
        {
            var check = check_tuple.Item2;
            var errors = check_tuple.Item1;
            return new CheckViewModel
            {
                checkID = check.Id,
                date = check.CreateOn,
                phrase = check.Phrase,
                isGrammarCorrect = check.isGrammCorrect,
                isSpellCorect = check.isSpellCorrect,
                errors = errors
            };
        }
    }
}
