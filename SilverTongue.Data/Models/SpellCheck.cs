using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SilverTongue.Data.Models
{
    public class SpellCheck
    {
        public int Id { get; set; }
        [ForeignKey("Check")]
        public int checkId { get; set; }
        public DateTime CreateOn { get; set; }
        [MaxLength(100)]
        public string Word { get; set; }
        [MaxLength(500)]
        public string OptionsSequence { get; set; }
        [IgnoreDataMember]
        public virtual Check Check { get; set; }
    }
}