using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SilverTongue.Data.Models.UserTests
{
    public class Question
    {
        public int id { get; set; }
        [ForeignKey("Test")]
        public int TestID { get; set; }
        [MaxLength(300)]
        public string Value { get; set; }
    }
}
