using Microsoft.EntityFrameworkCore;
using Plantopia.WebApi.Domains.Model.Device;
using Plantopia.WebApi.Domains.Model.Person;
using Plantopia.WebApi.Domains.Model.Plant;

namespace Plantopia.WebApi.Domains.Model
{
    public class PlantopiaDataContext : DbContext
    {
        private static bool _created;

        private readonly string connectionString;

        public PlantopiaDataContext(string connectionString)
        {
            this.connectionString = connectionString;
            RecreateDb();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<DeviceUserAccess> DeviceUserAccesses { get; set; }

        public DbSet<BaseDevice> BaseDevices { get; set; }

        public DbSet<DeviceInstance> DeviceInstances { get; set; }

        public DbSet<PlantType> PlantTypes { get; set; }

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
