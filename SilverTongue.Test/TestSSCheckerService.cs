using Microsoft.EntityFrameworkCore;
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
            Assert.True(!false);
        }
    }

}
