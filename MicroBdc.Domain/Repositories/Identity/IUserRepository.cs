using MicroBdc.Entities.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace MicroBdc.Domain.Repositories.Identity
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByUserName(string username);
        Task<User> FindByUserNameAsync(string username);
        Task<User> FindByUserNameAsync(CancellationToken cancellationToken, string username);
    }
}
