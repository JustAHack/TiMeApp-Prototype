using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiMePrototype.Application.DTOs.Shift
{
    public class ShiftDetailsDto : ShiftDto, IShiftDto
    {
        public int UserId { get; set; }
    }
}
