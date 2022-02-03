using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SilverTongue.Data.Models;

namespace SilverTongue.Data
{
    public class DbContext : IdentityDbContext
    {
        public DbContext(DbContextOptions options) : base(options) { }
        /// <summary>
        /// пользователи
        /// </summary>
        public virtual DbSet<Models.Users.User> Users { get; set; }
        /// <summary>
        /// Пользовательские словари
        /// </summary>
        public virtual DbSet<UsersDitctionary> UsersDicts { get; set; }
        /// <summary>
        /// Проверки орфографии
        /// </summary>
        public virtual DbSet<SpellCheck> SpellChecks { get; set; }
    }
}
