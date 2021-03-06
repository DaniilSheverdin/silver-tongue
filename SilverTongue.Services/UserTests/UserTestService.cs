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

        public Tuple<double, List<int>, List<int>> GetResult(List<int> answers, int TestID, int userID)
        {
          
            double mark = 0;

            var options = _db.Options.Where(o => o.isCorrect).Select(o => o.id).ToList();            
            var inter = options.Intersect(answers).ToList();
            var notCorrect = answers.Except(inter).ToList();

            if (inter.Count != 0)
            {
                mark = Math.Round((double)inter.Count / options.Count * 100, 2);
            }

            _db.Users.Find(userID).Points += Convert.ToInt32(mark);
            _db.TestResults.Add(new TestResult
            {
                TestID = TestID,
                date = DateTime.Now,
                UserID = userID,
                Percent = mark
            });
            _db.SaveChanges();

            return new Tuple<double, List<int>, List<int>>(mark, inter, notCorrect);
            
            
        }
    }
}
