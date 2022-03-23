using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using SilverTongue.Services.User;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SilverTongue.Test
{
    public class TestUserService
    {
        [Fact]
        public void UserService_GetAll_GivenTheyExist()
        {
            var options = new DbContextOptionsBuilder<Data.DbContext>()
                .UseInMemoryDatabase("gets_all").Options;
            using var context = new Data.DbContext(options);

            var service = new UserService(context);

            service.Create(new Data.Models.Users.User { Name = "Test1" }, "pass1");
            service.Create(new Data.Models.Users.User { Name = "Test2" }, "pass2");

            var allUsers = service.GetAll();
            allUsers.Count.Should().Be(2);
        }
        
    }
}
