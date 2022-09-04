using System.ComponentModel.DataAnnotations.Schema;
using TiMePrototype.Domain.Common;

namespace TiMePrototype.Domain;

public class Shift : BaseDomainEntity
{
    private decimal _dailyWage;
    private double _totalHours;

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public decimal HourlyRate { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }

    [NotMapped]
    public double TotalHours
    {
        get { return _totalHours; }
        private set
        {
            _totalHours = EndTime.Subtract(StartTime).TotalHours;
        }
    }

    [NotMapped]
    public decimal DailyWage
    {
        get { return _dailyWage; }
        private set 
        {
            _dailyWage = HourlyRate * (decimal)TotalHours;
        }
    }
}
