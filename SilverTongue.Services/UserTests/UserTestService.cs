using SilverTongue.Data;
using Microsoft.Extensions.Options;
using SilverTongue.Data.Models.UserTests;
using SilverTongue.Data.Users;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SilverTongue.Services.UserTests
{
    public class UserTestService : IUserTestService
    {
        private readonly DbContext _db;
        private readonly AppSettings _appSettings;
        public UserTestService(DbContext dbContext, IOptions<AppSettings> appSettings)
        {
            _db = dbContext;
            _appSettings = appSettings.Value;
        }
        public List<Test> GetAllTests()
        {
            return _db.Tests.ToList();
        }

        public List<Tuple<Question, List<Option>>> GetOneTest(int id)
        {
            List<Question> questions = _db.Questions.Where(q => q.TestID == id).ToList();

            List<Tuple<Question, List<Option>>> tuples = new List<Tuple<Question, List<Option>>>();
            foreach (var q in questions)
            {
                List<Option> options = _db.Options.Where(o => o.QuestionID == q.id).ToList();
                tuples.Add(new Tuple<Question, List<Option>>(q, options));
            }
            return tuples;
        }

        public ServiceResponse<double> GetResult(List<int> answers, int TestID, int userID)
        {
            try
            {
                double mark = 0;
                var questions = _db.Questions.Where(q => q.TestID == TestID).ToList();
                foreach (var q in questions)
                {
                    var options = _db.Options.Where(o => o.QuestionID == q.id && o.isCorrect).Select(o => o.id).ToList();

                    var inter = options.Intersect(answers).ToList();
                    if (inter.Count != 0)
                    {
                        mark = Math.Round((double)inter.Count / options.Count * 100, 2);
                    }
                    
                }

                _db.TestResults.Add(new TestResult
                {
                    TestID = TestID,
                    date = DateTime.Now,
                    UserID = userID,
                    Percent = mark
                });
                _db.SaveChanges();

                return new ServiceResponse<double>
                {
                    Data = mark,
                    IsSucces = true,
                    Message = "New result",
                    Time = DateTime.Now
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<double>
                {
                    Data = -1,
                    IsSucces = false,
                    Message = e.StackTrace,
                    Time = DateTime.Now
                };
            }
            
        }
    }
}
