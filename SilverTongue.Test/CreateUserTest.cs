using Microsoft.EntityFrameworkCore;
using SilverTongue.Services.User;
using Xunit;

namespace SilverTongue.Test
{
    public class CreateUserTest
    {
        [Fact]
        public void CreateUserTest_WhenIsOk()
        {
            var options = new DbContextOptionsBuilder<Data.DbContext>()
                .UseInMemoryDatabase("Add_writes_to_database").Options;
            using var context = new Data.DbContext(options);


            var user_service = new UserService(context);

            var response=user_service.Create(new Data.Models.Users.User { Name = "test1", Id = -1 }, "pass1");
            Assert.Equal("Success", response.Message);
        }

        [Fact]
        public void CreateUserTest_WhenIsNull()
        {
            var options = new DbContextOptionsBuilder<Data.DbContext>()
                .UseInMemoryDatabase("Add_writes_to_database").Options;
            using var context = new Data.DbContext(options);


            var user_service = new UserService(context);

            var response = user_service.Create(new Data.Models.Users.User { Name = "test1", Id = -1 }, "");
            Assert.Equal("Password is required", response.Message);
        }
        [Fact]
        public void CreateUserTest_WhenIsWhiteSpace()
        {
            var options = new DbContextOptionsBuilder<Data.DbContext>()
                .UseInMemoryDatabase("Add_writes_to_database").Options;
            using var context = new Data.DbContext(options);


            var user_service = new UserService(context);

            var response = user_service.Create(new Data.Models.Users.User { Name = "test1", Id = -1 }, " ");
            Assert.Equal("Password is required", response.Message);
        }
        [Fact]
        public void CreateUserTest_WhenNameTaken()
        {
            var options = new DbContextOptionsBuilder<Data.DbContext>()
                .UseInMemoryDatabase("Add_writes_to_database").Options;
            using var context = new Data.DbContext(options);


            var user_service = new UserService(context);

            user_service.Create(new Data.Models.Users.User { Name = "test1", Id = -1 }, "test1");
            var response = user_service.Create(new Data.Models.Users.User { Name = "test1", Id = -1 }, "test1");
            Assert.Equal("Username \""+"test1"+"\" is already taken", response.Message);
        }
    }
}
