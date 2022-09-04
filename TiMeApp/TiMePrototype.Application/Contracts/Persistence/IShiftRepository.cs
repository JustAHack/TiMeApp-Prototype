using TiMePrototype.Domain;

namespace TiMePrototype.Application.Contracts.Persistence;

public interface IShiftRepository : IGenericRepository<Shift>
{
    public Task<IReadOnlyList<Shift>> GetUsersShifts(int userId);
    public Task<IReadOnlyList<Shift>> GetUsersShiftsBetweenDates(int userId, DateTime start, DateTime end);
}
