using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiMePrototype.Application.DTOs.Common;

namespace TiMePrototype.Application.DTOs.Shift
{
    public class CreateShiftWithUserDto : ShiftDto, IShiftDto
    {
        public int UserId { get; set; }
    }
}
