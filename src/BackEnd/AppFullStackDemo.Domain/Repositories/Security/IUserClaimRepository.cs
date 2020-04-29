using System.Collections.Generic;
using AppFullStackDemo.Domain.Entities;
using AppFullStackDemo.Domain.Entities.Security;

namespace AppFullStackDemo.Domain.Repositories.Security
{
    public interface IUserClaimRepository
    {
        IEnumerable<UserClaim> GetByUser(User user);
    }
}