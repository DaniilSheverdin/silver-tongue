using SilverTongue.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace SilverTongue.Data
{
    public class UsersDitctionary
    {
        public int Id { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime UpdateOn { get; set; }
        [MaxLength(50)]
        public string Word { get; set; }
        [MaxLength(50)]
        public string Translate { get; set; }
        public User User { get; set; }
    }
}