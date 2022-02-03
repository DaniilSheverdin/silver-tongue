using SilverTongue.Web.ViewModels;

namespace SilverTongue.Web.Serialization
{
    public static class UserMapper
    {
        /// <summary>
        /// data to view
        /// </summary>
        /// <param name="model">data model</param>
        /// <returns></returns>
        public static UserModel SerializeUserModel(Data.Models.Users.User model)
        {
            return new UserModel
            {
                Id = model.Id,
                Name = model.Name,
                Points = model.Points
            };
        }
        /// <summary>
        /// view model (user) to data model
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static Data.Models.Users.User SerializeUserModel(UserModel model)
        {
            return new Data.Models.Users.User
            {
                Id = model.Id,
                Name = model.Name,
                Points = model.Points
            };
        }
        /// <summary>
        /// view model(registration) to data model
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static Data.Models.Users.User SerializeUserModel(RegisterModel model)
        {
            return new Data.Models.Users.User
            {
                Name = model.Name
            };
        }
    }
}
