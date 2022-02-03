using System.ComponentModel.DataAnnotations;

namespace SilverTongue.Web.ViewModels
{
    public class AuthenticateModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
