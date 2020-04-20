using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppFullStackDemo.Domain.Entities;

namespace AppFullStackDemo.Infra.Maps
{
    public class DeviceModelMap : IEntityTypeConfiguration<DeviceModel>
    {
        public void Configure(EntityTypeBuilder<DeviceModel> builder)
        {
            builder.ToTable("DeviceModel");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CreatedBy).IsRequired();
            builder.Property(c => c.UpdatedBy).IsRequired();
            builder.Property(c => c.CreatedIn).IsRequired();
            builder.Property(c => c.UpdatedIn).IsRequired();
            builder.Property(c => c.Status).IsRequired();

            builder
                .HasOne(p => p.Manufacturer)
                .WithMany(b => b.DevicesModel)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(c => c.Notifications);
        }
    }
}