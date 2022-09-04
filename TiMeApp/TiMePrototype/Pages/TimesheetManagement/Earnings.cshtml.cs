using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using TiMePrototype.Application.DTOs.Shift;
using TiMePrototype.Application.Features.Shift.Requests.Queries;
using TiMePrototype.Application.Services;

namespace TiMePrototype.Pages.TimesheetManagement;

[Authorize]
public class EarningsModel : PageModel
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly WageCalculator _wageCalculator;
    private decimal _weeklyWages;
    private decimal _fortnightlyWages;
    private decimal _monthsWages;

    public List<ShiftDto>? Shifts { get; private set; }

    [BindProperty]
    [DisplayName("Start date")]
    public DateTime StartDate { get; set; } = DateTime.Now.Date;
    [BindProperty]
    [DisplayName("End date")]
    public DateTime EndDate { get; set; } = DateTime.Now.Date.AddDays(1);

    [DisplayName("This weeks wages")]
    public decimal WeeklyWages
    {
        get { return _weeklyWages; }
        private set { _weeklyWages = value; }
    }

    [DisplayName("This fortnights wages")]
    public decimal FornightlyWages
    {
        get { return _fortnightlyWages; }
        private set { _fortnightlyWages = value; }
    }

    [DisplayName("This months wages")]
    public decimal MonthsWages
    {
        get { return _monthsWages; }
        private set { _monthsWages = value; }
    }

    public EarningsModel(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
        _wageCalculator = new WageCalculator(_mediator, _mapper);        
    }

    public async Task OnGet()
    {
        var userId = int.TryParse(User.Claims.FirstOrDefault(x => x.Type.Contains("Id"))!.Value, out int result);
        _weeklyWages = await _wageCalculator.CalculateWeeklyWages(result);
        _fortnightlyWages = await _wageCalculator.CalculateFortnightlyWages(result);
        _monthsWages = await _wageCalculator.CalculateThisMonthsWages(result);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var userId = int.TryParse(User.Claims.FirstOrDefault(x => x.Type.Contains("Id"))!.Value, out int result);
        _weeklyWages = await _wageCalculator.CalculateWeeklyWages(result);
        _fortnightlyWages = await _wageCalculator.CalculateFortnightlyWages(result);
        _monthsWages = await _wageCalculator.CalculateThisMonthsWages(result);

        Shifts = await _mediator.Send(new GetUsersShiftsInDateRangeRequest { UserId = result, StartDate = StartDate, EndDate = EndDate });
        return Page();
    }
}
