using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TiMePrototype.Application.DTOs.User;
using TiMePrototype.Application.Features.User.Requests.Commands;

namespace TiMePrototype.Pages.Account;

[AutoValidateAntiforgeryToken]
public class RegisterModel : PageModel
{
    private readonly IMediator _mediator;

    [BindProperty]
    public RegisterUserDto? Credential { get; set; }

    public RegisterModel(IMediator mediator)
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
            var command = new RegisterUserCommand { RegisterUserDto = Credential! };
            var response = await _mediator.Send(command);
            if (response.Success)
            {
                return RedirectToPage("/Index");
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