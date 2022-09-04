using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using TiMePrototype.Application.DTOs.User;
using TiMePrototype.Application.Features.User.Requests.Queries;

namespace TiMePrototype.Pages.Account;

[AutoValidateAntiforgeryToken]
public class LoginModel : PageModel
{
    private readonly IMediator _mediator;

    [BindProperty]
    public LoginUserDto? Credential { get; set; }

    public LoginModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        var user = await _mediator.Send(new VerifyLoginRequest() { user = Credential! });

        if (user == null) return Page();



        if (user != null)
        {
            // Create security context
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(type: "Id", value: user.Id.ToString())
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, "CookieAuth");
            ClaimsPrincipal claimsPrincipal = new(identity);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = Credential!.RememberMe,
            };

            await HttpContext.SignInAsync("CookieAuth", claimsPrincipal, authProperties);

            return RedirectToPage("/TimesheetManagement/Shifts");
        }
        return Page();
    }
}