using AutoMapper;
using SilverTongue.Data.Models.Users;
using SilverTongue.Web.ViewModels;

namespace SilverTongue.Web.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
            CreateMap<RegisterModel, User>();
        }
    }
}
