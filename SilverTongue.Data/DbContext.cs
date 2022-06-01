using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SilverTongue.Data.Models;
using SilverTongue.Data.Models.UserTests;

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
        /// <summary>
        /// Проверки
        /// </summary>
        public virtual DbSet<Check> Checks { get; set; }
        /// <summary>
        /// Варианты ответов на вопрос теста
        /// </summary>
        public virtual DbSet<Option> Options { get; set; }
        /// <summary>
        /// Вопросы тестов
        /// </summary>
        public virtual DbSet<Question> Questions { get; set; }
        /// <summary>
        /// Тесты
        /// </summary>
        public virtual DbSet<Test> Tests { get; set; }
        /// <summary>
        /// Результаты тестов
        /// </summary>
        public virtual DbSet<TestResult> TestResults { get; set; }
    }
}
