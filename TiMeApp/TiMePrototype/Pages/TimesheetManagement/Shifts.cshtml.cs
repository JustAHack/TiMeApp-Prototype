using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TiMePrototype.Application.DTOs.Shift;
using TiMePrototype.Application.Features.Shift.Requests.Queries;

namespace TiMePrototype.Pages.TimesheetManagement
{
    [Authorize]
    public class ShiftsModel : PageModel
    {
        private readonly IMediator _mediator;

        public List<ShiftDto>? Shifts { get; private set; }

        public ShiftsModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task OnGet()
        {
            var claims = HttpContext.User.Claims;
            var id = claims.FirstOrDefault(x => x.Type.Contains("Id"))!.Value;
            _ = int.TryParse(id, out int Id);
            Shifts = await _mediator.Send(new GetUsersShiftsRequest{ UserId = Id });
        }
    }
}
