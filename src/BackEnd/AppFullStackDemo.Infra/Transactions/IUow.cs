using System.Threading.Tasks;

namespace AppFullStackDemo.Infra.Transactions
{
    public interface IUow
    {
        Task Commit();

        void Rollback();
    }
}