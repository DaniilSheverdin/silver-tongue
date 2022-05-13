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
                .UseInMemoryDatabase("Add_writes_to_database1").Options;
            using var context = new Data.DbContext(options);
            var user_service = new UserService(context);
            var response = user_service.Create(new Data.Models.Users.User { Name = "test1", Id = -1 }, "pass1");
            Assert.Equal("Success", response.Message);
        }
        [Fact]
        public void CreateUserTest_WhenIsOk2()
        {
            var options = new DbContextOptionsBuilder<Data.DbContext>()
                .UseInMemoryDatabase("Add_writes_to_database2").Options;
            using var context = new Data.DbContext(options);
            var user_service = new UserService(context);
            var response = user_service.Create(new Data.Models.Users.User { Name = "fefnwnf232", Id = -1 }, "pass1");
            Assert.Equal("Success", response.Message);
        }
        [Fact]
        public void CreateUserTest_WhenIsOk3()
        {
            var options = new DbContextOptionsBuilder<Data.DbContext>()
                .UseInMemoryDatabase("Add_writes_to_database3").Options;
            using var context = new Data.DbContext(options);
            var user_service = new UserService(context);
            var response = user_service.Create(new Data.Models.Users.User { Name = "*******lo", Id = -1 }, "pass1");
            Assert.Equal("Success", response.Message);
        }
        [Fact]
        public void CreateUserTest_WhenIsOk4()
        {
            var options = new DbContextOptionsBuilder<Data.DbContext>()
                .UseInMemoryDatabase("Add_writes_to_database4").Options;
            using var context = new Data.DbContext(options);
            var user_service = new UserService(context);
            var response = user_service.Create(new Data.Models.Users.User { Name = "loloo", Id = -1 }, "12__-_(");
            Assert.Equal("Success", response.Message);
        }
        [Fact]
        public void CreateUserTest_WhenIsOk5()
        {
            var options = new DbContextOptionsBuilder<Data.DbContext>()
                .UseInMemoryDatabase("Add_writes_to_database5").Options;
            using var context = new Data.DbContext(options);
            var user_service = new UserService(context);
            var response = user_service.Create(new Data.Models.Users.User { Name = "loloo", Id = -1 }, "*");
            Assert.Equal("Success", response.Message);
        }
        [Fact]
        public void CreateUserTest_WhenLoginTooLong()
        {
            var options = new DbContextOptionsBuilder<Data.DbContext>()
                .UseInMemoryDatabase("Add_writes_to_database6").Options;
            using var context = new Data.DbContext(options);


            var user_service = new UserService(context);

            var response = user_service.Create(new Data.Models.Users.User { Name = "teeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeest1", Id = -1 }, "pass1");
            Assert.Equal("Login is too long", response.Message);
        }
        [Fact]
        public void CreateUserTest_WhenLoginTooLong2()
        {
            var options = new DbContextOptionsBuilder<Data.DbContext>()
                .UseInMemoryDatabase("Add_writes_to_database16").Options;
            using var context = new Data.DbContext(options);


            var user_service = new UserService(context);

            var response = user_service.Create(new Data.Models.Users.User { Name = "teeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeest1", Id = -1 }, "pass1");
            Assert.Equal("Login is too long", response.Message);
        }
        [Fact]
        public void CreateUserTest_WhenLoginTooLong3()
        {
            var options = new DbContextOptionsBuilder<Data.DbContext>()
                .UseInMemoryDatabase("Add_writes_to_database1").Options;
            using var context = new Data.DbContext(options);


            var user_service = new UserService(context);

            var response = user_service.Create(new Data.Models.Users.User { Name = "teeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeest1", Id = -10 }, "pass1");
            Assert.Equal("Login is too long", response.Message);
        }
        [Fact]
        public void CreateUserTest_WhenLoginTooLong4()
        {
            var options = new DbContextOptionsBuilder<Data.DbContext>()
                .UseInMemoryDatabase("Add_writes_to_database17").Options;
            using var context = new Data.DbContext(options);


            var user_service = new UserService(context);

            var response = user_service.Create(new Data.Models.Users.User { Name = "teeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeest1", Id = -2 }, "pass1");
            Assert.Equal("Login is too long", response.Message);
        }
        [Fact]
        public void CreateUserTest_WhenLoginTooLong5()
        {
            var options = new DbContextOptionsBuilder<Data.DbContext>()
                .UseInMemoryDatabase("Add_writes_to_database17").Options;
            using var context = new Data.DbContext(options);


            var user_service = new UserService(context);

            var response = user_service.Create(new Data.Models.Users.User { Name = "teeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeest1", Id = -7 }, "pass1");
            Assert.Equal("Login is too long", response.Message);
        }
        [Fact]
        public void CreateUserTest_WhenPassTooLong()
        {
            var options = new DbContextOptionsBuilder<Data.DbContext>()
                .UseInMemoryDatabase("Add_writes_to_database7").Options;
            using var context = new Data.DbContext(options);


            var user_service = new UserService(context);

            var response = user_service.Create(new Data.Models.Users.User { Name = "test1", Id = -1 }, "paaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaass1");
            Assert.Equal("Password is too long", response.Message);
        }
        [Fact]
        public void CreateUserTest_WhenPassTooLong2()
        {
            var options = new DbContextOptionsBuilder<Data.DbContext>()
                .UseInMemoryDatabase("Add_writes_to_database8").Options;
            using var context = new Data.DbContext(options);


            var user_service = new UserService(context);

            var response = user_service.Create(new Data.Models.Users.User { Name = "test1", Id = -1 }, "paaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaass1");
            Assert.Equal("Password is too long", response.Message);
        }
        [Fact]
        public void CreateUserTest_WhenPassTooLong3()
        {
            var options = new DbContextOptionsBuilder<Data.DbContext>()
                .UseInMemoryDatabase("Add_writes_to_database8").Options;
            using var context = new Data.DbContext(options);


            var user_service = new UserService(context);

            var response = user_service.Create(new Data.Models.Users.User { Name = "test1", Id = -1 }, "paaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaass1");
            Assert.Equal("Password is too long", response.Message);
        }
        [Fact]
        public void CreateUserTest_WhenPassTooLong4()
        {
            var options = new DbContextOptionsBuilder<Data.DbContext>()
                .UseInMemoryDatabase("Add_writes_to_database8").Options;
            using var context = new Data.DbContext(options);


            var user_service = new UserService(context);

            var response = user_service.Create(new Data.Models.Users.User { Name = "test1", Id = -1 }, "paaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaass1");
            Assert.Equal("Password is too long", response.Message);
        }
        [Fact]
        public void CreateUserTest_WhenPassTooLong5()
        {
            var options = new DbContextOptionsBuilder<Data.DbContext>()
                .UseInMemoryDatabase("Add_writes_to_database8").Options;
            using var context = new Data.DbContext(options);


            var user_service = new UserService(context);

            var response = user_service.Create(new Data.Models.Users.User { Name = "test1", Id = -1 }, "paaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaass1");
            Assert.Equal("Password is too long", response.Message);
        }
        [Fact]
        public void CreateUserTest_WhenIsNull()
        {
            var options = new DbContextOptionsBuilder<Data.DbContext>()
                .UseInMemoryDatabase("Add_writes_to_database8").Options;
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
            Assert.Equal("Username \"" + "test1" + "\" is already taken", response.Message);
        }
    }
}