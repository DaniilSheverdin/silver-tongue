using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SilverTongue.Web.ViewModels
{
    public class TestModel
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string About { get; set; }
    }
}
