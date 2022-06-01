using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SilverTongue.Data.Models.UserTests
{
    /// <summary>
    /// результат теста 
    /// </summary>
    public class TestResult
    {
        public int id { get; set; }
        [ForeignKey("Test")]
        public int TestID { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public double Percent { get; set; }
        public DateTime date { get; set; }
    }
}
