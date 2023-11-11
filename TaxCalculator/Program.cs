
using TaxCalculator.Data;
using TaxCalculator.Interfaces;
using TaxCalculator.Models;
using TaxCalculator.Services;

using (var dbContext = new ApplicationDbContext())
{
    DatabaseInitializer.SeedData(dbContext);
}

CongestionTaxCalculator calculator = new CongestionTaxCalculator();

List<DateTime> dates = new List<DateTime>
{
    DateTime.Parse("2013-01-14 21:00:00"),
    DateTime.Parse("2013-01-15 21:00:00"),
    DateTime.Parse("2013-02-07 06:23:27"),
    DateTime.Parse("2013-02-07 15:27:00"),
    DateTime.Parse("2013-02-08 06:27:00"),
    DateTime.Parse("2013-02-08 06:20:27"),
    DateTime.Parse("2013-02-08 14:35:00"),
    DateTime.Parse("2013-02-08 15:29:00"),
    DateTime.Parse("2013-02-08 15:47:00"),
    DateTime.Parse("2013-02-08 16:01:00"),
    DateTime.Parse("2013-02-08 16:48:00"),
    DateTime.Parse("2013-02-08 17:49:00"),
    DateTime.Parse("2013-02-08 18:29:00"),
    DateTime.Parse("2013-02-08 18:35:00"),
    DateTime.Parse("2013-03-26 14:25:00"), 
    DateTime.Parse("2013-03-28 14:07:27")
};

IVehicle Corolla = new Car("Corolla");

int totalToll = calculator.GetTax(Corolla, dates);
Console.WriteLine($"Total Congestion Tax for {Corolla.GetVehicleType()} is: {totalToll} SEK");
Console.ReadLine();