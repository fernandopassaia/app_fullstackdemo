using System.Collections.Generic;
using AppFullStackDemo.Domain.Entities.Security;

namespace AppFullStackDemo.Domain.Repositories.Security
{
    public interface IClaimRepository
    {
        IEnumerable<Claim> Get();
    }
}