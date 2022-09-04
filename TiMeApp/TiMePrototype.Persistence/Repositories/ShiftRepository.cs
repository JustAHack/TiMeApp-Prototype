using Microsoft.EntityFrameworkCore;
using TiMePrototype.Application.Contracts.Persistence;
using TiMePrototype.Domain;

namespace TiMePrototype.Persistence.Repositories;

public class ShiftRepository : GenericRepository<Shift>, IShiftRepository
{
	private readonly TiMeDbContext _context;

	public ShiftRepository(TiMeDbContext context) : base(context)
	{
		_context = context;
	}

    public async Task<IReadOnlyList<Shift>> GetUsersShifts(int userId)
    {
        return await _context.Set<Shift>().AsNoTracking().Where(x => x.UserId == userId).OrderByDescending(x => x.StartTime).ToListAsync();
    }

	public async Task<IReadOnlyList<Shift>> GetUsersShiftsBetweenDates(int userId, DateTime start, DateTime end)
	{
		return await _context.Set<Shift>().AsNoTracking().Where(x => x.UserId == userId && x.StartTime >= start && x.EndTime <= end).ToListAsync();
	}
}
