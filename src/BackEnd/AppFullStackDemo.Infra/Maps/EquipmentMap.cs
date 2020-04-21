using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppFullStackDemo.Domain.Entities;

namespace AppFullStackDemo.Infra.Maps
{
    public class EquipmentMap : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.ToTable("Equipment");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.AndroidId).HasMaxLength(30).IsRequired();
            builder.Property(c => c.Imei1).HasMaxLength(30);
            builder.Property(c => c.Imei2).HasMaxLength(30);
            builder.Property(c => c.PhoneNumber).HasMaxLength(30);
            builder.Property(c => c.MacAddress).HasMaxLength(30);
            builder.Property(c => c.ApiLevel).HasMaxLength(10).IsRequired();
            builder.Property(c => c.ApiLevelDesc).HasMaxLength(30).IsRequired();
            builder.Property(c => c.SerialNumber).HasMaxLength(40);
            builder.Property(c => c.SystemName).HasMaxLength(20);
            builder.Property(c => c.SystemVersion).HasMaxLength(20).IsRequired();

            builder.Property(c => c.CreatedBy).IsRequired();
            builder.Property(c => c.UpdatedBy).IsRequired();
            builder.Property(c => c.CreatedIn).IsRequired();
            builder.Property(c => c.UpdatedIn).IsRequired();

            builder
              .HasOne(p => p.User)
              .WithMany(b => b.EquipmentsList)
              .OnDelete(DeleteBehavior.Restrict);

            builder
              .HasOne(p => p.DeviceModel)
              .WithMany(b => b.EquipmentsList)
              .OnDelete(DeleteBehavior.Cascade); //ON EF: Tables with Multiple FK can have just one Cascade

            builder.Ignore(c => c.Notifications);
        }
    }
}