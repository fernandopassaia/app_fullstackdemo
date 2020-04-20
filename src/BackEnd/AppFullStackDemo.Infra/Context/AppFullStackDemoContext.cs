using AppFullStackDemo.Domain.Entities;
using AppFullStackDemo.Infra.Maps;
using Microsoft.EntityFrameworkCore;

namespace AppFullStackDemo.Infra.Context
{
    public class AppFullStackDemoContext : DbContext
    {
        //Note: Docs about these maps, relatinships can be found inside the Entities (Models)
        //Note: 18092019 starting migration to PostgreSQL Database. Wow!

        #region Constructor and DbSets

        public AppFullStackDemoContext(DbContextOptions<AppFullStackDemoContext> options) : base(options)
        {
        }

        public AppFullStackDemoContext()
        {
        }

        public DbSet<DeviceModel> DeviceModel { get; set; }

        public DbSet<Equipment> Equipment { get; set; }

        public DbSet<Manufacturer> Manufacturer { get; set; }

        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) //if it's not configured and not comming from anysource, I'll use the default connection here
            {
                optionsBuilder.UseSqlServer("Data Source=FUTURADATA\\FUTURADATA2014,2469;Initial Catalog=MobileControl;Persist Security Info=True;User ID=sa;Password=@1234#");
            }
        }

        #endregion Constructor and DbSets

        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new EquipmentMap());
            builder.ApplyConfiguration(new DeviceModelMap());
            builder.ApplyConfiguration(new ManufacturerMap());
        }

        #endregion OnModelCreating
    }
}