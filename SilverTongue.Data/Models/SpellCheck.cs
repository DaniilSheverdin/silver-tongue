using System;
using System.ComponentModel.DataAnnotations;

namespace SilverTongue.Data.Models
{
    public class SpellCheck
    {
        public int Id { get; set; }
        public Check Check { get; set; }
        public DateTime CreateOn { get; set; }
        [MaxLength(100)]
        public string Word { get; set; }
        [MaxLength(500)]
        public string OptionsSequence { get; set; }
    }
}