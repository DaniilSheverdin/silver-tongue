using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using SilverTongue.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SilverTongue.Services.User
{
    public class UserService : IUserService
    {
        private readonly DbContext _db;
        public UserService(DbContext dbContext)
        {
            _db = dbContext;
        }
        public ServiceResponse<Data.Models.User> AddUser(Data.Models.User note)
        {
            try
            {
                // generate a 128-bit salt using a cryptographically strong random sequence of nonzero values
                byte[] salt = new byte[128 / 8];
                using (var rngCsp = new RNGCryptoServiceProvider())
                {
                    rngCsp.GetNonZeroBytes(salt);
                }

                // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: note.Password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));
                note.Password = hashed;
                note.Points = 0;
                note.UpdateOn = DateTime.UtcNow;
                note.CreateOn = DateTime.UtcNow;
                _db.Users.Add(note);
                _db.SaveChanges();

                return new ServiceResponse<Data.Models.User>
                {
                    Data = note,
                    Time = DateTime.UtcNow,
                    Message = "Saved new User",
                    IsSucces = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.User>
                {
                    Data = note,
                    Time = DateTime.UtcNow,
                    Message = e.StackTrace,
                    IsSucces = false
                };
            }
        }

        public ServiceResponse<Data.Models.User> DeleteNote(int id)
        {
            try
            {
                var note = _db.Users.Find(id);
                _db.Users.Remove(note);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.User>
                {
                    Data = note,
                    Time = DateTime.UtcNow,
                    Message = "Deleted note",
                    IsSucces = true
                };

            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.User>
                {
                    Data = null,
                    Time = DateTime.UtcNow,
                    Message = e.StackTrace,
                    IsSucces = false
                };
            }
        }

        public List<Data.Models.User> GetAllUser()
        {
            return _db.Users.OrderByDescending(user=>user.Points).ToList();
        }

        public Data.Models.User GetById(int id)
        {
            return _db.Users.Find(id);
        }
    }
}
