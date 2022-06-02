using AutoMapper;
using SilverTongue.Data.Models.Users;
using SilverTongue.Data.Models.UserTests;
using SilverTongue.Web.ViewModels;
using System;
using System.Collections.Generic;

namespace SilverTongue.Web.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
            CreateMap<RegisterModel, User>();
            CreateMap<Test, TestModel>();
        }
    }
}
