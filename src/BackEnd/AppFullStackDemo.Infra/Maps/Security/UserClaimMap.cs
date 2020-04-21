using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppFullStackDemo.Domain.Entities.Security;

namespace AppFullStackDemo.Infra.Maps
{
    public class UserClaimMap : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.ToTable("UserClaim");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CreatedBy).IsRequired();
            builder.Property(c => c.UpdatedBy).IsRequired();
            builder.Property(c => c.CreatedIn).IsRequired();
            builder.Property(c => c.UpdatedIn).IsRequired();

            builder
              .HasOne(p => p.User)
              .WithMany(b => b.UserClaimList)
              .OnDelete(DeleteBehavior.Restrict);

            builder
              .HasOne(p => p.Claim)
              .WithMany(b => b.UserClaimList)
              .OnDelete(DeleteBehavior.Cascade); //ON EF: Tables with Multiple FK can have just one Cascade

            builder.Ignore(c => c.Notifications);
        }
    }
}