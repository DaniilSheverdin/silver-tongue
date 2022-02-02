using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SilverTongue.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime UpdateOn { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string Password { get; set; }
        /// <summary>
        /// Количество очков для рейтинга
        /// </summary>
        public int Points { get; set; }
    }
}
