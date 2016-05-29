using MicroBdc.Data.EntityFramework.Configuration.Identity;
using MicroBdc.Entities.Identity;
using System.Data.Entity;

namespace MicroBdc.Data.EntityFramework.Context
{
    internal class IdentityDbContext : DbContext
    {
        public IdentityDbContext()
            : base("name=MicroBdcIdentity")
        {
        }

        public IdentityDbContext(string nameOrConnectionString)
            : base("name=MicroBdcIdentity")
        {
        }

        internal IDbSet<User> Users { get; set; }
        internal IDbSet<Role> Roles { get; set; }
        internal IDbSet<ExternalLogin> Logins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new ExternalLoginConfiguration());
            modelBuilder.Configurations.Add(new ClaimConfiguration());
        }
    }
}
