using SilverTongue.Data.Models;
using System;
using System.Collections.Generic;

namespace SilverTongue.Web.ViewModels
{
    public class CheckViewModel
    {
        public int checkID { get; set; }
        public string phrase { get; set; }
        public DateTime date { get; set; }
        public bool isSpellCorect { get; set; }
        public bool isGrammarCorrect { get; set; }
        public List<SpellCheckModel> errors { get; set; }
    }
    public class SpellCheckModel
    {
        public int id { get; set; }
        public string word { get; set; }
        public string optionsSequence { get; set; }
    }
}
