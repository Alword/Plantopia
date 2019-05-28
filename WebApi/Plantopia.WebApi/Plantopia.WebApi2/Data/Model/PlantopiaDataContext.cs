using Microsoft.EntityFrameworkCore;
using Plantopia.WebApi2.Data.Model.Person;

namespace Plantopia.WebApi2.Data.Model
{
    /// <inheritdoc />
    /// <summary>
    /// Base application context about all data
    /// </summary>
    public class PlantopiaDataContext : DbContext
    {
        private static bool _created;

        private readonly string connectionString;

        /// <inheritdoc />
        /// <summary>
        /// Base ctor
        /// </summary>
        /// <param name="connectionString"></param>
        public PlantopiaDataContext(string connectionString)
        {
            this.connectionString = connectionString;
            RecreateDb();
        }

        /// <summary>
        /// Users set
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Accounts set
        /// </summary>
        public DbSet<Account> Accounts { get; set; }

        /// <summary>
        /// Accounts set
        /// </summary>
        public DbSet<Account> Accounts { get; set; }


        /// <inheritdoc />
        /// <summary>
        /// Configuration builder
        /// </summary>
        /// <param name="optionBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseMySql(connectionString);
        }

        private void RecreateDb()
        {
            if (_created) return;

            _created = true;
            Database.EnsureCreated();
        }
    }
}
