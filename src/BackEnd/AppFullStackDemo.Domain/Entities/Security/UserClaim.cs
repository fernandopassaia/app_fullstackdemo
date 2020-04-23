namespace AppFullStackDemo.Domain.Entities.Security
{
    public class UserClaim : EntityBase
    {
        public UserClaim(User user, Claim claim)
        {
            User = user;
            Claim = claim;
        }

        protected UserClaim() { } //This constructor will be used by EF during migrations (for some reason, EF needs a empty constructor to run)

        public Claim Claim { get; private set; }

        public User User { get; private set; }

        public void Update(User user, Claim claim)
        {
            User = user;
            Claim = claim;
        }

        public override void Validate()
        {

        }
    }
}