using System;
using System.ComponentModel.DataAnnotations;

namespace SilverTongue.Data.Models.Users
{
    public class User
    {
        public int Id { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime UpdateOn { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        /// <summary>
        /// Количество очков для рейтинга
        /// </summary>
        public int Points { get; set; }
    }
}
