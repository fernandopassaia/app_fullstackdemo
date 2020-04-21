using AppFullStackDemo.Infra.Context;
using System.Threading.Tasks;

namespace AppFullStackDemo.Infra.Transactions
{
    public class Uow : IUow
    {
        private readonly AppFullStackDemoContext _context;

        public Uow(AppFullStackDemoContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Rollback()
        {
            // Do nothing yet, but we can do a log, or something, in future
        }
    }
}