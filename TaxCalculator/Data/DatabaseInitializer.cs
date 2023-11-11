using Microsoft.EntityFrameworkCore;
using TaxCalculator.Models;

namespace TaxCalculator.Data;

public static class DatabaseInitializer
{
            public static void SeedData(ApplicationDbContext dbContext)
        {
            dbContext.Database.Migrate();
            // Check if there are any existing records
            if (!dbContext.TimeIntervals.Any())
            {
                // Add default values
                dbContext.TimeIntervals.Add(new TimeInterval (new TimeSpan(6, 0, 0), new TimeSpan(6, 29, 59), 8 ));
                dbContext.TimeIntervals.Add(new TimeInterval(new TimeSpan(6, 30, 0), new TimeSpan(6, 59, 59), 13));
                dbContext.TimeIntervals.Add(new TimeInterval(new TimeSpan(7, 0, 0), new TimeSpan(7, 59, 59), 18));
                dbContext.TimeIntervals.Add(new TimeInterval(new TimeSpan(8, 0, 0), new TimeSpan(8, 29, 59), 13));
                dbContext.TimeIntervals.Add(new TimeInterval(new TimeSpan(8, 30, 0), new TimeSpan(14, 59, 59), 8));
                dbContext.TimeIntervals.Add(new TimeInterval(new TimeSpan(15, 0, 0), new TimeSpan(15, 29, 59), 13));
                dbContext.TimeIntervals.Add(new TimeInterval(new TimeSpan(15, 30, 0), new TimeSpan(16, 59, 59), 18));
                dbContext.TimeIntervals.Add(new TimeInterval(new TimeSpan(17, 0, 0), new TimeSpan(17, 59, 59), 13));
                dbContext.TimeIntervals.Add(new TimeInterval(new TimeSpan(18, 0, 0), new TimeSpan(18, 29, 59), 8));
                dbContext.TimeIntervals.Add(new TimeInterval(new TimeSpan(18, 30, 0), new TimeSpan(23, 59, 59), 0));
                dbContext.TimeIntervals.Add(new TimeInterval(new TimeSpan(0, 0, 0), new TimeSpan(5, 59, 59), 0));
                dbContext.SaveChanges();
            }
            
            if (!dbContext.TaxFreeDates.Any())
            {
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 1, 1), Type = "PublicHoliday"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 1, 2), Type = "PublicHoliday"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 2, 6), Type = "PublicHoliday"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 6, 12), Type = "PublicHoliday"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 10, 23), Type = "PublicHoliday"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 11, 9), Type = "PublicHoliday"});

                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 1), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 2), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 3), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 4), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 5), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 6), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 7), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 8), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 9), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 10), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 11), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 12), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 13), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 14), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 15), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 16), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 17), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 18), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 19), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 20), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 21), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 22), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 23), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 24), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 25), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 26), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 27), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 28), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 29), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 30), Type = "TaxFreeDay"});
                dbContext.TaxFreeDates.Add(new TaxFreeDate {Date = new DateTime(2013, 7, 31), Type = "TaxFreeDay"});
                dbContext.SaveChanges();
            }
        }
}