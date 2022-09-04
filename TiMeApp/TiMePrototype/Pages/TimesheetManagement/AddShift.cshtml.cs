using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using TiMePrototype.Application.DTOs.Shift;
using TiMePrototype.Application.Features.Shift.Requests.Commands;
using TiMePrototype.Domain;

namespace TiMePrototype.Pages.TimesheetManagement
{
    [Authorize]
    public class ShiftModel : PageModel
    {
        private readonly IMediator _mediator;

        [BindProperty]
        public CreateShiftWithUserDto? Shift { get; set; }

        public ShiftModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            try
            {
                var claims = HttpContext.User.Claims;
                var id = claims.FirstOrDefault(x => x.Type.Contains("Id"))!.Value;
                _ = int.TryParse(id, out int Id);
                Shift!.UserId = Id;
                var command = new CreateShiftWithUserCommand { ShiftDto = Shift };
                var response = await _mediator.Send(command);
                if (response.Success)
                {
                    return RedirectToPage("./Shifts");
                }

                if (response.ValidationErrors.Any())
                {
                    foreach (var error in response.ValidationErrors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                return Page();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            return Page();
        }
    }
}
