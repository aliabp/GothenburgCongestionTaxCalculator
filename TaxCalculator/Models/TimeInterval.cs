using System.ComponentModel.DataAnnotations;

namespace TaxCalculator.Models;

public class TimeInterval
{
    [Key]
    public int Id { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public int Amount { get; set; }

    public TimeInterval(TimeSpan startTime, TimeSpan endTime, int amount)
    {
        StartTime = startTime;
        EndTime = endTime;
        Amount = amount;
    }
}