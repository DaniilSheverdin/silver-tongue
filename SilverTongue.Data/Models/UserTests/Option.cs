using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SilverTongue.Data.Models.UserTests
{
    public class Option
    {
        public int id { get; set; }
        [ForeignKey("Question")]
        public int QuestionID { get; set; }
        [MaxLength(300)]
        public string Value { get; set; }
        public bool isCorrect { get; set; }
    }
}
