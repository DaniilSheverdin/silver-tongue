using System.ComponentModel.DataAnnotations;

namespace SilverTongue.Web.ViewModels
{
    public class RegisterModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
