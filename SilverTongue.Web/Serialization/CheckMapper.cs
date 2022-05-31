using SilverTongue.Data.Models;
using SilverTongue.Web.ViewModels;
using System;
using System.Collections.Generic;

namespace SilverTongue.Web.Serialization
{
    public static class CheckMapper
    {
        /// <summary>
        /// Data model to view model (for checkig)
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static CheckViewModel SerializeCheckModel(Tuple<List<SpellCheck>, Check> check_tuple)
        {
            var check = check_tuple.Item2;
            var errors = check_tuple.Item1;
            List< SpellCheckModel > m_error= new List<SpellCheckModel>();
            foreach (var e in errors)
            {
                m_error.Add(new SpellCheckModel { id = e.Id, word=e.Word, optionsSequence=e.OptionsSequence });
            }
            return new CheckViewModel
            {
                checkID = check.Id,
                date = check.CreateOn,
                phrase = check.Phrase,
                isGrammarCorrect = check.isGrammCorrect,
                isSpellCorect = check.isSpellCorrect,
                errors = m_error
            };
        }
        /// <summary>
        /// Data model of Check list to view model (for getting archive)
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static List<CheckViewModel> SerializeArchiveModel(List<Check> check)
        {
            List<CheckViewModel> archive = new List<CheckViewModel>();
            foreach (var e in check)
            {
                archive.Add(new CheckViewModel
                {
                    checkID=e.Id,
                    isGrammarCorrect=e.isGrammCorrect,
                    isSpellCorect=e.isSpellCorrect,
                    errors=null,
                    date=e.CreateOn,
                    phrase=e.Phrase
                });
            }
            return archive;
        }
    }
}
