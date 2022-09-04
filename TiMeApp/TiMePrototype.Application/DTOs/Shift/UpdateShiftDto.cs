namespace TiMePrototype.Application.DTOs.Shift;

public class UpdateShiftDto : ShiftDto, IShiftDto
{
    public int UserId { get; set; }
}
