using MicroBdc.Entities.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace MicroBdc.Domain.Repositories.Identity
{
    public interface IRoleRepository : IRepository<Role>
    {
        Role FindByName(string roleName);
        Task<Role> FindByNameAsync(string roleName);
        Task<Role> FindByNameAsync(CancellationToken cancellationToken, string roleName);
    }
}
