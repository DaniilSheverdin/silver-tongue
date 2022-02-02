using SilverTongue.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilverTongue.Web.Serialization
{
    public static class SpellMapper
    {
        /// <summary>
        /// data to view
        /// </summary>
        /// <param name="model">data model</param>
        /// <returns></returns>
        public static SpellCheckModel SerializeSpellModel(Data.Models.SpellCheckModel model)
        {
            return new SpellCheckModel
            {
                id=model.id,
                word=model.word
            };
        }
        /// <summary>
        /// view model to data model
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static Data.Models.SpellCheckModel SerializeSpellModel(SpellCheckModel model)
        {
            return new Data.Models.SpellCheckModel
            {
                id=model.id,
                word=model.word
            };
        }
    }
}
