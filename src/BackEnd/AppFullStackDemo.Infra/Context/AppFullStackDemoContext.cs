using AppFullStackDemo.Domain.Entities;
using AppFullStackDemo.Domain.Entities.Security;
using AppFullStackDemo.Infra.Maps;
using AppFullStackDemo.Infra.Maps.Security;
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

        public DbSet<DeviceModel> DeviceModels { get; set; }

        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Claim> Claims { get; set; }

        public DbSet<UserClaim> UserClaims { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) //if it's not configured and not comming from anysource, I'll use the default connection here
            {
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=AppFullStackDemo;Persist Security Info=True;User ID=sa;Password=@1234Fd@");
            }
        }

        #endregion Constructor and DbSets

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ClaimMap());
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new ManufacturerMap());
            builder.ApplyConfiguration(new UserClaimMap());
            builder.ApplyConfiguration(new DeviceModelMap());
            builder.ApplyConfiguration(new EquipmentMap());
        }
        #endregion
    }
}