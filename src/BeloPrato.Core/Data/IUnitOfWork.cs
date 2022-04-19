using System.Threading.Tasks;

namespace BeloPrato.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
