using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TiMePrototype.Application.DTOs.Shift;
using TiMePrototype.Application.Features.Shift.Requests.Commands;
using TiMePrototype.Application.Features.Shift.Requests.Queries;

namespace TiMePrototype.Pages.TimesheetManagement
{
    [Authorize]
    public class EditShiftModel : PageModel
    {
        private readonly IMediator _mediator;

        [BindProperty]
        public ShiftDetailsDto? Shift { get; set; }

        public EditShiftModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> OnGet(int Id)
        {
            Shift = await _mediator.Send(new GetShiftDetailsRequest() { Id = Id });

            // Get current logged in user Id
            var claims = HttpContext.User.Claims;
            var id = claims.FirstOrDefault(x => x.Type.Contains("Id"))!.Value;
            _ = int.TryParse(id, out int userId);

            if (Shift == null)
                return RedirectToPage("./Shifts");

            if (Shift.UserId != userId)
                return RedirectToPage("./Shifts");

            return Page();
        }

        public async Task<IActionResult> OnPost(int Id)
        {
            if (!ModelState.IsValid) return Page();

            // Get current logged in user Id
            var claims = HttpContext.User.Claims;
            var id = claims.FirstOrDefault(x => x.Type.Contains("Id"))!.Value;
            _ = int.TryParse(id, out int userId);

            try
            {
                Shift!.Id = Id;
                Shift!.UserId = userId;
                var command = new UpdateShiftCommand { ShiftDto = Shift! };
                var response = await _mediator.Send(command);

                return RedirectToPage("./EditShift", new { Id = Shift.Id });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                return RedirectToPage("./Shifts");
            }
        }
    }
}
