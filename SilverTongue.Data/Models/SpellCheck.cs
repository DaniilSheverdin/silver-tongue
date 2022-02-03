using System;
using System.ComponentModel.DataAnnotations;

namespace SilverTongue.Data.Models
{
    public class SpellCheck
    {
        public int Id { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime UpdateOn { get; set; }
        [MaxLength(100)]
        public string InputWord { get; set; }
        [MaxLength(300)]
        public string OptionsSequence { get; set; }
        public bool isCorrect { get; set; }
        public Users.User User { get; set; }
    }
}