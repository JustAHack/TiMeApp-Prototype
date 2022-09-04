using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TiMePrototype.Application.Features.Shift.Requests.Commands;

namespace TiMePrototype.Pages.TimesheetManagement;

[Authorize]
public class DeleteShiftModel : PageModel
{
    private readonly IMediator _mediator;

    public DeleteShiftModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> OnPost(int Id)
    {
        try
        {
            var command = new DeleteShiftCommand { Id = Id };
            await _mediator.Send(command);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message.ToString());
        }

        return RedirectToPage("./Shifts");
    }
}
