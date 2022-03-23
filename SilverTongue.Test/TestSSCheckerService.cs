/*using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using SilverTongue.Services.Checker;
using SilverTongue.Services.User;
using Xunit;

namespace SilverTongue.Test
{
    public class TestSSCheckerService
    {
        [Fact]
        public void SSCheckerService_CheckerIsCorrect()
        {
            var options = new DbContextOptionsBuilder<Data.DbContext>()
                .UseInMemoryDatabase("Add_writes_to_database").Options;
            using var context = new Data.DbContext(options);


            var user_service = new UserService(context);
            var service = new SymSpellCheckerService(context);

            user_service.Create(new Data.Models.Users.User { Name = "test1", Id = -1 }, "pass1");
            user_service.Create(new Data.Models.Users.User { Name = "test2", Id = -2 }, "pass2");

            var correct=service.SpellCheck("hello",-1);
            var mistake=service.SpellCheck("helo", -2);

            correct.Data.isCorrect.Should().Be(true);
            mistake.Data.isCorrect.Should().Be(false);
        }
    }
}
*/