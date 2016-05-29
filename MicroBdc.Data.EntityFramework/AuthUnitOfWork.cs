using MicroBdc.Data.EntityFramework.Repositories.Identity;
using MicroBdc.Domain;
using MicroBdc.Domain.Repositories.Identity;
using MicroBdc.Data.EntityFramework.Context;
using System.Threading.Tasks;

namespace MicroBdc.Data.EntityFramework
{
    public class AuthUnitOfWork : IAuthUnitOfWork
    {
        #region Fields
        private readonly IdentityDbContext _context;
        private IExternalLoginRepository _externalLoginRepository;
        private IRoleRepository _roleRepository;
        private IUserRepository _userRepository;
        #endregion

        #region Constructors
        public AuthUnitOfWork(string nameOrConnectionString)
        {
            _context = new IdentityDbContext(nameOrConnectionString);
        }
        #endregion

        #region IUnitOfWork Members
        public IExternalLoginRepository ExternalLoginRepository
        {
            get { return _externalLoginRepository ?? (_externalLoginRepository = new ExternalLoginRepository(_context)); }
        }

        public IRoleRepository RoleRepository
        {
            get { return _roleRepository ?? (_roleRepository = new RoleRepository(_context)); }
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_context)); }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            _externalLoginRepository = null;
            _roleRepository = null;
            _userRepository = null;
            _context.Dispose();
        }
        #endregion
    }
}
