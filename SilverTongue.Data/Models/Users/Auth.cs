using System;
using System.Collections.Generic;
using System.Text;

namespace SilverTongue.Data.Models.Users
{
    public class Auth
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }

        public Auth(User user, string token)
        {
            Id = user.Id;
            Name = user.Name;
            Token = token;
        }
    }
}
