namespace AppFullStackDemo.Domain.Entities.Security
{
    public class UserClaim : EntityBase
    {
        public UserClaim(User user, Claim claim)
        {
            User = user;
            Claim = claim;
        }

        public Claim Claim { get; private set; }

        public User User { get; private set; }

        public void Update(User user, Claim claim)
        {
            User = user;
            Claim = claim;
        }
    }
}