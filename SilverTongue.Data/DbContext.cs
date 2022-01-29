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

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersDitctionary> UsersDicts { get; set; }
    }
}
