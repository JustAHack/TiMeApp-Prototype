using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TiMePrototype.Application.DTOs.Shift;
using TiMePrototype.Application.Features.Shift.Requests.Queries;

namespace TiMePrototype.Pages.TimesheetManagement;

[Authorize]
public class ShiftDetailsModel : PageModel
{
    private readonly IMediator _mediator;

    public ShiftDetailsDto Shift { get; set; }

    public ShiftDetailsModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> OnGetAsync(int Id)
    {
        var userId = int.TryParse(User.Claims.FirstOrDefault(x => x.Type.Contains("Id"))!.Value, out int result);
        Shift = await _mediator.Send(new GetShiftDetailsRequest { Id = Id });

        if (Shift == null)
            return RedirectToPage("./Shifts");

        if (Shift.UserId != result)
            return RedirectToPage("./Shifts");

        return Page();
    }
}
