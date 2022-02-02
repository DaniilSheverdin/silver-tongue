using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SilverTongue.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilverTongue.Data
{
    public class DbContext : IdentityDbContext
    {
        public DbContext(DbContextOptions options) : base(options) { }
        /// <summary>
        /// пользователи
        /// </summary>
        public virtual DbSet<User> Users { get; set; }
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
