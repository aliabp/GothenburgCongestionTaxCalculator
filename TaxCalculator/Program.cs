
using TaxCalculator.Data;

using (var dbContext = new ApplicationDbContext())
{
    DatabaseInitializer.SeedData(dbContext);
}

Console.WriteLine("Tax Amount: ");