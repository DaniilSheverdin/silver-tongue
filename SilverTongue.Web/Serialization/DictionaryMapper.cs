using SilverTongue.Web.ViewModels;
using System;

namespace SilverTongue.Web.Serialization
{
    public static class DictionaryMapper
    {
        /// <summary>
        /// Data model to view model
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static DictionaryModel SerializeDictionaryModel(Data.Models.UsersDitctionary dict)
        {
            return new DictionaryModel
            {
                Word = dict.Word,
                Translate = dict.Translate
            };
        }
        /// <summary>
        /// view model to data model
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static Data.Models.UsersDitctionary SerializeDictionaryModel(DictionaryModel dict)
        {
            return new Data.Models.UsersDitctionary
            {
                CreateOn = DateTime.UtcNow,
                UpdateOn = DateTime.UtcNow,
                Word = dict.Word.ToLower(),
                Translate = dict.Translate.ToLower()
            };
        }
    }
}
