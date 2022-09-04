using MediatR;
using TiMePrototype.Application.Contracts.Persistence;
using TiMePrototype.Application.Features.Shift.Requests.Commands;
using TiMePrototype.Application.Exceptions;

namespace TiMePrototype.Application.Features.Shift.Handlers.Commands;

public class DeleteShiftCommandHandler : IRequestHandler<DeleteShiftCommand, Unit>
{
	private readonly IShiftRepository _shiftRepository;

	public DeleteShiftCommandHandler(IShiftRepository shiftRepository)
	{
		_shiftRepository = shiftRepository;
	}

	public async Task<Unit> Handle(DeleteShiftCommand request, CancellationToken cancellationToken)
	{
		var shift = await _shiftRepository.GetAsync(request.Id);
		if (shift == null)
			throw new NotFoundException(nameof(shift), request.Id);

		await _shiftRepository.DeleteAsync(shift);
		return Unit.Value;
	}
}
