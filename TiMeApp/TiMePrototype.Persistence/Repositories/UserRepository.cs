using Microsoft.EntityFrameworkCore;
using TiMePrototype.Application.Contracts.Persistence;
using TiMePrototype.Domain;

namespace TiMePrototype.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly TiMeDbContext _context;

        public UserRepository(TiMeDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> UserNameExists(string username)
        {
            var entity = await _context.Set<User>().FirstOrDefaultAsync(x => x.UserName == username);
            return entity != null;
        }

        public async Task<User?> VerifyUser(string username)
        {
            return await _context.Set<User>().AsNoTracking().FirstOrDefaultAsync(x => x.UserName == username);
        }
    }
}
