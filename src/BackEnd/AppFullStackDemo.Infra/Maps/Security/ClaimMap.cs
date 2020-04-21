using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppFullStackDemo.Domain.Entities.Security;

namespace AppFullStackDemo.Infra.Maps.Security
{
    public class ClaimMap : IEntityTypeConfiguration<Claim>
    {
        public void Configure(EntityTypeBuilder<Claim> builder)
        {
            builder.ToTable("Claim");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ClaimName).HasMaxLength(40).IsRequired();
            builder.Property(c => c.ClaimUrlOpt).HasMaxLength(80).IsRequired();
            builder.Property(c => c.CreatedBy).IsRequired();
            builder.Property(c => c.UpdatedBy).IsRequired();
            builder.Property(c => c.CreatedIn).IsRequired();
            builder.Property(c => c.UpdatedIn).IsRequired();
            builder.Property(c => c.Status).IsRequired();

            builder.Ignore(c => c.Notifications);
        }
    }
}