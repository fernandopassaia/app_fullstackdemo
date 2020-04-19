using Flunt.Validations;
using System.Collections.Generic;

namespace AppFullStackDemo.Domain.Entities.Security
{
    public class Claim : EntityBase
    {
        public Claim(string claimName, string claimUrlOpt)
        {
            ClaimName = claimName;
            ClaimUrlOpt = claimUrlOpt;
            Validate();
        }
        public string ClaimName { get; private set; }

        public string ClaimUrlOpt { get; private set; }

        public List<UserClaim> UserClaimList { get; private set; }

        public void Update(string claimName, string claimUrlOpt)
        {
            ClaimName = claimName;
            ClaimUrlOpt = claimUrlOpt;
            Validate();
        }

        public void Validate()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(ClaimName, "ClaimName", "Please inform a Name for Claim.")
                .HasMaxLengthIfNotNullOrEmpty(ClaimName, 40, "ClaimName", "Name of the Claim could not be higher than 40c.")
                .HasMaxLengthIfNotNullOrEmpty(ClaimUrlOpt, 80, "ClaimUrlOpt", "DescriptionUrl could not be higher than 80c.")
            );
        }
    }
}