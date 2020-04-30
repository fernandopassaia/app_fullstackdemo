using System.Collections.Generic;
using System.Linq;
using AppFullStackDemo.Domain.Entities;
using AppFullStackDemo.Domain.Entities.Security;
using AppFullStackDemo.Domain.Repositories.Security;
using AppFullStackDemo.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace AppFullStackDemo.Infra.Repositories.Security
{
    public class UserClaimRepository : IUserClaimRepository
    {
        private readonly AppFullStackDemoContext _context;

        public UserClaimRepository(AppFullStackDemoContext context)
        {
            _context = context;
        }

        public void AddUserClaims(List<UserClaim> usersClaims)
        {
            _context.UserClaims.AddRange(usersClaims);
        }

        public IEnumerable<UserClaim> GetByUser(User user)
        {
            var userClaims = _context.UserClaims
                .Include(p => p.User)
                .Include(p => p.Claim)
                .Where(p => p.User == user).ToList();

            return userClaims;
        }
    }
}