using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppFullStackDemo.Domain.Entities;

namespace AppFullStackDemo.Infra.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.AditionalInfo).IsRequired().HasMaxLength(200);
            builder.Property(c => c.CreatedBy).IsRequired();
            builder.Property(c => c.UpdatedBy).IsRequired();
            builder.Property(c => c.CreatedIn).IsRequired();
            builder.Property(c => c.UpdatedIn).IsRequired();
            builder.Property(c => c.Status).IsRequired();

            // here i had to (1) show all my valueobject and (2) says to EF ignore the Notifications inside it
            // Note: By Default EF will create fields with the ValueObject name (Address_Street, Address_City, Name_FirstName)
            // If you want to gave your own custom name just add an annotattion to it: HasColumnName("FirstName")
            builder.OwnsOne(c => c.Address).Property(c => c.Street).IsRequired();
            builder.OwnsOne(c => c.Address).Property(c => c.StreetNumber).HasMaxLength(20).IsRequired();
            builder.OwnsOne(c => c.Address).Property(c => c.NeighborHood).HasMaxLength(60).IsRequired();
            builder.OwnsOne(c => c.Address).Property(c => c.City).HasMaxLength(60).IsRequired();
            builder.OwnsOne(c => c.Address).Property(c => c.ZipCode).HasMaxLength(10);

            builder.OwnsOne(c => c.Name).Property(c => c.FirstName).HasMaxLength(40).IsRequired();
            builder.OwnsOne(c => c.Name).Property(c => c.LastName).HasMaxLength(80).IsRequired();

            builder.OwnsOne(c => c.Document).Property(c => c.CountryRegistryNumber).HasMaxLength(20).IsRequired();
            builder.OwnsOne(c => c.Document).Property(c => c.StateRegistryNumber).HasMaxLength(20);

            builder.OwnsOne(c => c.Phone).Property(c => c.PhoneNumber1).HasMaxLength(20);
            builder.OwnsOne(c => c.Phone).Property(c => c.PhoneNumber2).HasMaxLength(20);
            builder.OwnsOne(c => c.Phone).Property(c => c.MobilePhoneNumber1).HasMaxLength(20);
            builder.OwnsOne(c => c.Phone).Property(c => c.MobilePhoneNumber2).HasMaxLength(20);

            builder.OwnsOne(c => c.Email).Property(c => c.EmailAddress).HasMaxLength(100).IsRequired();

            builder.OwnsOne(c => c.UserAccount).Ignore(p => p.Notifications);
            builder.OwnsOne(c => c.UserAccount).Property(c => c.UserName).HasMaxLength(100).IsRequired();
            builder.OwnsOne(c => c.UserAccount).Property(c => c.Password).HasMaxLength(120).IsRequired();
            builder.Ignore(c => c.Notifications);
        }
    }
}