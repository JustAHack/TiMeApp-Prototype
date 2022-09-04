using TiMePrototype.Domain;

namespace TiMePrototype.Application.Contracts.Persistence;

public interface IUserRepository : IGenericRepository<User>
{
    Task<bool> UserNameExists(string username);
    Task<User?> VerifyUser(string username);
}
