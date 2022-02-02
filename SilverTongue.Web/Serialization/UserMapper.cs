using SilverTongue.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilverTongue.Web.Serialization
{
    public static class UserMapper
    {
        /// <summary>
        /// Data model to view model
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static UserModel SerializeUserModel(Data.Models.User user)
        {
            return new UserModel
            {
                Id = user.Id,
                CreateOn = user.CreateOn,
                UpdateOn = user.UpdateOn,
                Name = user.Name,
                Password=user.Password,
                Points=user.Points
            };
        }
        /// <summary>
        /// view model to data model
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static Data.Models.User SerializeUserModel(UserModel user)
        {
            return new Data.Models.User
            {
                Id = user.Id,
                CreateOn = user.CreateOn,
                UpdateOn = user.UpdateOn,
                Name = user.Name,
                Password = user.Password,
                Points=user.Points
            };
        }
    }
}
