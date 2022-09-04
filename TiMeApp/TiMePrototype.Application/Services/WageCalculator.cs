using AutoMapper;
using MediatR;
using System.Globalization;
using TiMePrototype.Application.DTOs.Shift;
using TiMePrototype.Application.Features.Shift.Requests.Queries;
using TiMePrototype.Domain;

namespace TiMePrototype.Application.Services
{
    public class WageCalculator
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly CultureInfo _cultureInfo;
        private readonly DayOfWeek _startOfWeek;
        private readonly DateTime _startOfWeekDate;

        public WageCalculator(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
            _cultureInfo = CultureInfo.CurrentCulture;
            _startOfWeek = _cultureInfo.DateTimeFormat.FirstDayOfWeek;
        }

        public async Task<decimal> CalculateWeeklyWages(int userId)
        {
            var date = DateTime.Now;
            var day = date.DayOfWeek;
            DateTime start = date.AddDays( (-1) * (day == 0 ? 7 : (int)day - 1));
            DateTime end = start.AddDays(7);

            var shifts = await _mediator.Send(new GetUsersShiftsInDateRangeRequest { UserId = userId, StartDate = start, EndDate = end });

            shifts = _mapper.Map<List<ShiftDto>>(shifts);

            return CalculateWages(shifts);
        }

        public decimal CalculateWages(List<ShiftDto> shifts)
        {
            decimal wages = 0;

            foreach (var shift in shifts)
            {
                wages += shift.HourlyRate * (decimal)shift.TotalHours;
            }

            return wages;
        }

        public async Task<decimal> CalculateFortnightlyWages(int userId)
        {
            var date = DateTime.Now;
            var day = date.DayOfWeek;
            DateTime start = date.AddDays((-1) * (day == 0 ? 7 : (int)day - 1)).Subtract(TimeSpan.FromDays(14));
            DateTime end = date;

            var shifts = await _mediator.Send(new GetUsersShiftsInDateRangeRequest { UserId = userId, StartDate = start, EndDate = end });

            shifts = _mapper.Map<List<ShiftDto>>(shifts);

            return CalculateWages(shifts);
        }

        public async Task<decimal> CalculateThisMonthsWages(int userId)
        {
            var date = DateTime.Now;
            DateTime start = new DateTime(date.Year, date.Month, 1);
            DateTime end = start.AddMonths(1).AddSeconds(-1);

            var shifts = await _mediator.Send(new GetUsersShiftsInDateRangeRequest { UserId = userId, StartDate = start, EndDate = end });

            shifts = _mapper.Map<List<ShiftDto>>(shifts);

            return CalculateWages(shifts);
        }
    }
}
