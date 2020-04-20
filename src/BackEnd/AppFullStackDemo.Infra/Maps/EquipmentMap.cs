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
            builder.Property(c => c.AndroidId).HasColumnName("AndroidId").HasMaxLength(30).IsRequired();
            builder.Property(c => c.Imei1).HasColumnName("Imei1").HasMaxLength(30);
            builder.Property(c => c.Imei2).HasColumnName("Imei2").HasMaxLength(30);
            builder.Property(c => c.PhoneNumber).HasColumnName("PhoneNumber").HasMaxLength(30);
            builder.Property(c => c.MacAddress).HasColumnName("MacAddress").HasMaxLength(30);
            builder.Property(c => c.ApiLevel).HasColumnName("ApiLevel").HasMaxLength(10).IsRequired();
            builder.Property(c => c.ApiLevelDesc).HasColumnName("ApiLevelDesc").HasMaxLength(30).IsRequired();
            builder.Property(c => c.SerialNumber).HasColumnName("SerialNumber").HasMaxLength(40);
            builder.Property(c => c.SystemName).HasColumnName("SystemName").HasMaxLength(20);
            builder.Property(c => c.SystemVersion).HasColumnName("SystemVersion").HasMaxLength(20).IsRequired();

            builder.Property(c => c.CreatedBy).HasColumnName("CreatedBy").IsRequired();
            builder.Property(c => c.UpdatedBy).HasColumnName("UpdatedBy").IsRequired();
            builder.Property(c => c.CreatedIn).HasColumnName("CreatedIn").IsRequired();
            builder.Property(c => c.UpdatedIn).HasColumnName("UpdatedIn").IsRequired();

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