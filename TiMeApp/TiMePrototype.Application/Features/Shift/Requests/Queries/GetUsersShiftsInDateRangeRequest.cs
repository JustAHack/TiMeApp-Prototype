using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiMePrototype.Application.DTOs.Shift;

namespace TiMePrototype.Application.Features.Shift.Requests.Queries
{
    public class GetUsersShiftsInDateRangeRequest : IRequest<List<ShiftDto>>
    {
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
