using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilverTongue.Web.ViewModels
{
    public class UserModel
    {
        public int Id { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime UpdateOn { get; set; }

        public string Name { get; set; }
        public int Points { get; set; }
        public string Password { get; set; }
    }
}
