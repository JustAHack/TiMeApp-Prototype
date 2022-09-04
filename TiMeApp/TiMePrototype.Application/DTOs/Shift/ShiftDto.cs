using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TiMePrototype.Application.DTOs.Common;

namespace TiMePrototype.Application.DTOs.Shift
{
    public class ShiftDto : BaseDto, IShiftDto
    {
        private decimal _dailyWage;
        private double _totalHours;

        [DisplayName("Start time")]
        public DateTime StartTime { get; set; }

        [DisplayName("End time")]
        public DateTime EndTime { get; set; }

        [DisplayName("Hourly rate")]
        public decimal HourlyRate { get; set; }

        [NotMapped]
        [DisplayName("Hours")]
        public double TotalHours
        {
            get { return _totalHours; }
            private set
            {
                _totalHours = EndTime.Subtract(StartTime).TotalHours;
            }
        }

        [NotMapped]
        [DisplayName("Wage")]
        public decimal DailyWage
        {
            get { return _dailyWage; }
            private set
            {
                _dailyWage = HourlyRate * (decimal)TotalHours;
            }
        }

        public decimal CalculateDailyWage()
        {
            _dailyWage = HourlyRate * (decimal)EndTime.Subtract(StartTime).TotalHours;
            return _dailyWage;
        }
    }
}
