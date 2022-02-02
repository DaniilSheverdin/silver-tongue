using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilverTongue.Web.ViewModels
{
    public class DictionaryModel
    {
        public int Id { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime UpdateOn { get; set; }
        public string Word { get; set; }
        public string Translate { get; set; }
        public UserModel User { get; set; }
    }
}
