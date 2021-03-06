using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SilverTongue.Data;
using SilverTongue.Data.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SilverTongue.Services.User
{
    public class UserService : IUserService
    {
        private readonly DbContext _db;
        private readonly AppSettings _appSettings;
        public UserService(DbContext dbContext, IOptions<AppSettings> appSettings)
        {
            _db = dbContext;
            _appSettings = appSettings.Value;
        }
        public Data.Models.Users.User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _db.Users.SingleOrDefault(x => x.Name == username);
            if (user == null)
                return null;
            // check if username exists
            if (user.Name == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.Password, user.Salt))
                return null;

            return user;
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
        public ServiceResponse<Data.Models.Users.User> Create(Data.Models.Users.User user, string password)
        {
            try
            {
                // validation
                if (string.IsNullOrWhiteSpace(password))
                    throw new Exception("Введите пароль!");
                if (password.Length >= 30)
                    throw new Exception("Длина пароля должна быть меньше 30 символов");
                if (user.Name.Length >= 30)
                    throw new Exception("Длина логина должна быть меньше 30 символов");

                if (_db.Users.Any(x => x.Name == user.Name))
                    throw new Exception("Пользователь \"" + user.Name + "\" уже существует");

                CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
                user.CreateOn = DateTime.UtcNow;
                user.UpdateOn = DateTime.UtcNow;
                user.Password = passwordHash;
                user.Salt = passwordSalt;

                _db.Users.Add(user);
                _db.SaveChanges();

                return new ServiceResponse<Data.Models.Users.User>
                {
                    Data = user,
                    Time = DateTime.UtcNow,
                    Message = "Success",
                    IsSucces = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.Users.User>
                {
                    Data = null,
                    Time = DateTime.UtcNow,
                    Message = e.Message,
                    IsSucces = false
                };
            }

        }
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public ServiceResponse<Data.Models.Users.User> Delete(int id)
        {
            try
            {
                var user = _db.Users.Find(id);
                if (user != null)
                {
                    _db.Users.Remove(user);
                    _db.SaveChanges();
                }
                return new ServiceResponse<Data.Models.Users.User>
                {
                    Data = user,
                    Time = DateTime.UtcNow,
                    Message = "Deleted user",
                    IsSucces = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.Users.User>
                {
                    Data = null,
                    Time = DateTime.UtcNow,
                    Message = e.StackTrace,
                    IsSucces = false
                };
            }
        }
        public List<Data.Models.Users.User> GetAll()
        {
            return _db.Users.OrderByDescending(user => user.Points).ToList();
        }
        public Data.Models.Users.User GetById(int id)
        {
            return _db.Users.Find(id);
        }
    }
}
