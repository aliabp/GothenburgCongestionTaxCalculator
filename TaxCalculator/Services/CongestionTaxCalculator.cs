using Microsoft.Extensions.Configuration;
using TaxCalculator.Data;
using TaxCalculator.Interfaces;
using TaxCalculator.Models;

namespace TaxCalculator.Services;

public class CongestionTaxCalculator
{
    // Get options from app settings
    private readonly IConfiguration _config;
    
    // Store dates excluding taxes in Single Charge Rule period
    private List<Toll> _distinctDates;
    
    // Maximum tax amount per a day for a vehicle
    private readonly int _maxLimit;
    
    // Single Charge Rule period
    private readonly int _singleChargeMinutes;
    
    // Tax intervals defined by admin
    // It stores in database
    private readonly List<TimeInterval> _taxIntervals;
    
    // Public Holidays defined by admin
    // It stores in database
    private readonly List<DateTime> _publicHolidays;
    
    // Tax-free days defined by admin
    // It stores in database
    private readonly List<DateTime> _taxFreeDates;
    
    // Weekend defined by admin, because it's possible to weekend be different in different countries
    // It stores in app settings
    private readonly List<DayOfWeek> _weekend;
    
    // Vehicle have been exempted from toll, defined by admin
    // It stores in app settings
    private readonly List<string> _tollFreeVehicles;
    
    public CongestionTaxCalculator()
    {
        _config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .Build();
        _distinctDates = new List<Toll>();
        _taxIntervals = new List<TimeInterval>();
        _publicHolidays = new List<DateTime>();
        _taxFreeDates = new List<DateTime>();
        _weekend = new List<DayOfWeek>();
        try
        {
            // Get Maximum tax amount per a day for a vehicle from app settings
            _maxLimit = int.Parse(_config["MaxLimit"].ToString());
            
            // Get Single Charge Rule period from app settings
            _singleChargeMinutes = int.Parse(_config["SingleChargeMinutes"].ToString());

            // Get weekend array from app settings
            var weekend = _config.GetSection("Weekend").AsEnumerable();
            foreach (var day in weekend)
            {
                if (day.Value != null)
                    _weekend.Add((DayOfWeek)Enum.Parse(typeof(DayOfWeek), day.Value));
            }

            // Get exempted vehicles array from app settings
            _tollFreeVehicles = new List<string>();
            var vehicles = _config.GetSection("TollFreeVehicles").AsEnumerable();
            foreach (var vehicle in vehicles)
            {
                if (vehicle.Value != null)
                    _tollFreeVehicles.Add(vehicle.Value);
            }
            
            // Read tax rules data from database 
            using (var dbContext = new ApplicationDbContext())
            {
                _taxIntervals = dbContext.TimeIntervals.ToList();

                _publicHolidays = dbContext.TaxFreeDates
                    .Where(d => d.Type == "PublicHoliday")
                    .Select(x => x.Date )
                    .ToList();
                
                _taxFreeDates = dbContext.TaxFreeDates
                    .Where(d => d.Type == "TaxFreeDay")
                    .Select(x => x.Date )
                    .ToList();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    private int GetTollFee(DateTime date)
    {
        int tollAmount = 0;
        try
        {
            // Get tax amount from defined time intervals
            foreach (TimeInterval interval in _taxIntervals)
            {
                TimeSpan currentTime = date.TimeOfDay;
                if (currentTime >= interval.StartTime && currentTime <= interval.EndTime)
                    tollAmount = interval.Amount;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return tollAmount;
    }
    
    private bool IsTollFreeDate(DateTime date)
    {
        try
        {
            // Check if the date is tax-free
            if (_taxFreeDates.Contains(date.Date))
            {
                Console.WriteLine($"Date {date} is in tax free days.");
                return true;
            }

            // Check if the date is a weekend
            if (_weekend.Contains(date.DayOfWeek))
            {
                Console.WriteLine($"Date {date} is weekend.");
                return true;
            }

            // Check if the date is a public holiday or day before a public holiday
            if (_publicHolidays.Contains(date.Date) || IsDayBeforePublicHoliday(date))
            {
                Console.WriteLine($"Date {date} is in public holidays.");
                return true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
            
        return false;
    }

    private bool IsDayBeforePublicHoliday(DateTime date)
    {
        List<DateTime> daysBeforePublicHoliday = new List<DateTime>();
        try
        {
            foreach (var holiday in _publicHolidays)
            {
                // Find days before holidays
                daysBeforePublicHoliday.Add(holiday.AddDays(-1));
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return daysBeforePublicHoliday.Contains(date.Date);
    }
    
    private bool IsTollFreeVehicle(IVehicle vehicle)
    {
        if (vehicle == null) return false;
        string vehicleType = "";
        try
        {
            vehicleType = vehicle.GetVehicleType();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
            
        return _tollFreeVehicles.Contains(vehicleType);
    }
}