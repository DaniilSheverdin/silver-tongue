using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SilverTongue.Data.Models
{
    public class Check
    {

        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public DateTime CreateOn { get; set; }
        [MaxLength(1000)]
        public string Phrase { get; set; }
        [MaxLength(500)]
        public bool isSpellCorrect { get; set; }
        public bool isGrammCorrect { get; set; }

        [IgnoreDataMember]
        public virtual Users.User User { get; set; }
    }
}
