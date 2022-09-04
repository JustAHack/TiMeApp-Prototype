namespace TiMePrototype.Application.DTOs.Shift;

public interface IShiftDto
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public decimal HourlyRate { get; set; }
}
