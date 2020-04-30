using System.Collections.Generic;
using System.Linq;
using AppFullStackDemo.Domain.Entities.Security;
using AppFullStackDemo.Domain.Repositories.Security;
using AppFullStackDemo.Infra.Context;

namespace AppFullStackDemo.Infra.Repositories.Security
{
    public class ClaimRepository : IClaimRepository
    {
        private readonly AppFullStackDemoContext _context;

        public ClaimRepository(AppFullStackDemoContext context)
        {
            _context = context;
        }

        public IEnumerable<Claim> Get()
        {
            var claims = _context.Claims
                .ToList();

            return claims;
        }
    }
}