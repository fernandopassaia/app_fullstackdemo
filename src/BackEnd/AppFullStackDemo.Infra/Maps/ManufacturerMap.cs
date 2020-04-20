using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppFullStackDemo.Domain.Entities;

namespace AppFullStackDemo.Infra.Maps
{
    public class ManufacturerMap : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.ToTable("Manufacturer");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Description).IsRequired().HasMaxLength(30);
            builder.Property(c => c.CreatedBy).IsRequired();
            builder.Property(c => c.UpdatedBy).IsRequired();
            builder.Property(c => c.CreatedIn).IsRequired();
            builder.Property(c => c.UpdatedIn).IsRequired();
            builder.Property(c => c.Status).IsRequired();

            //here i had to (1) show all my valueobject and (2) says to EF ignore the Notifications inside it
            builder.Ignore(c => c.Notifications);
        }
    }
}