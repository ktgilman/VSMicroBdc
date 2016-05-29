﻿using MicroBdc.Entities.Identity;
using MicroBdc.Domain.Repositories.Identity;
using MicroBdc.Data.EntityFramework.Context;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MicroBdc.Data.EntityFramework.Repositories.Identity
{
    internal class RoleRepository : Repository<Role>, IRoleRepository
    {
        internal RoleRepository(IdentityDbContext context)
            : base(context)
        {
        }

        public Role FindByName(string roleName)
        {
            return Set.FirstOrDefault(x => x.Name == roleName);
        }

        public Task<Role> FindByNameAsync(string roleName)
        {
            return Set.FirstOrDefaultAsync(x => x.Name == roleName);
        }

        public Task<Role> FindByNameAsync(System.Threading.CancellationToken cancellationToken, string roleName)
        {
            return Set.FirstOrDefaultAsync(x => x.Name == roleName, cancellationToken);
        }
    }
}
