using SilverTongue.Data.Models.UserTests;
using SilverTongue.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilverTongue.Web.Serialization
{
    public class TestMapper
    {
        public static List<OneTestModel> SerializeOneTest(List<Tuple<Question, List<Option>>> tuple)
        {
            List<OneTestModel> res = new List<OneTestModel>();
            foreach (var n in tuple)
            {

                res.Add(new OneTestModel()
                {
                    Options= n.Item2.Select(p => new OptionModel {
                        id = p.id,
                        Value = p.Value
                    }).ToList(),
                    Question = n.Item1.Value
                }); ;
            }
            return res;
        }
    }
}
