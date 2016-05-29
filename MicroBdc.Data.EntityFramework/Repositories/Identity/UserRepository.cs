using MicroBdc.Entities.Identity;
using MicroBdc.Domain.Repositories.Identity;
using MicroBdc.Data.EntityFramework.Context;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MicroBdc.Data.EntityFramework.Repositories.Identity
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        internal UserRepository(IdentityDbContext context)
            : base(context)
        {
        }

        public User FindByUserName(string username)
        {
            return Set.FirstOrDefault(x => x.UserName == username);
        }

        public Task<User> FindByUserNameAsync(string username)
        {
            return Set.FirstOrDefaultAsync(x => x.UserName == username);
        }

        public Task<User> FindByUserNameAsync(System.Threading.CancellationToken cancellationToken, string username)
        {
            return Set.FirstOrDefaultAsync(x => x.UserName == username, cancellationToken);
        }
    }
}
