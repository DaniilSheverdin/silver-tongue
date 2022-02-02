using SilverTongue.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                Id = dict.Id,
                CreateOn = dict.CreateOn,
                UpdateOn = dict.UpdateOn,
                User = UserMapper.SerializeUserModel(dict.User),
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
                Id = dict.Id,
                CreateOn = dict.CreateOn,
                UpdateOn = dict.UpdateOn,
                User = UserMapper.SerializeUserModel(dict.User),
                Word = dict.Word,
                Translate = dict.Translate
            };
        }
    }
}
