using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilverTongue.Web.ViewModels
{
    public class OneTestModel
    {
        public string Question { get; set; }
        public List<OptionModel> Options { get; set; }
    }

    public class OptionModel
    {
        public int id { get; set; }
        public string Value { get; set; }
    }
}
