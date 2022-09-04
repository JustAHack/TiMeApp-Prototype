using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TiMePrototype.Application.DTOs.Shift;

namespace TiMePrototype.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public ShiftDto? Shift { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost([FromForm] ShiftDto shift)
    {
        if (!ModelState.IsValid) return Page();
        Shift = new ShiftDto()
        {
            StartTime = shift.StartTime,
            EndTime = shift.EndTime,
            HourlyRate = shift.HourlyRate
        };

        Shift.CalculateDailyWage();

        return Page();
    }
}

