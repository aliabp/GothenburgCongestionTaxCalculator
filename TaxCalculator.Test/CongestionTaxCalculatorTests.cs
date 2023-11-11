using TaxCalculator.Models;
using TaxCalculator.Services;
using Xunit;

namespace TaxCalculator.Test;

public class CongestionTaxCalculatorTests
{
    [Fact]
    public void GetTax_WithTollFreeVehicle_ShouldReturnZero()
    {
        // Arrange
        var calculator = new CongestionTaxCalculator();
        var vehicle = new Car("Motorcycle");
        var dates = new List<DateTime>
        {
            DateTime.Parse("2013-01-14 21:00:00"),
            DateTime.Parse("2013-01-15 21:00:00")
        };

        // Act
        var result = calculator.GetTax(vehicle, dates);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GetTax_WithTollFreeDate_ShouldReturnZero()
    {
        // Arrange
        var calculator = new CongestionTaxCalculator();
        var vehicle = new Car("Car");
        var dates = new List<DateTime>
        {
            DateTime.Parse("2013-07-01 12:00:00"),
            DateTime.Parse("2013-07-02 12:00:00")
        };

        // Act
        var result = calculator.GetTax(vehicle, dates);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GetTax_WithWeekendDate_ShouldReturnZero()
    {
        // Arrange
        var calculator = new CongestionTaxCalculator();
        var vehicle = new Car("Car");
        var dates = new List<DateTime>
        {
            DateTime.Parse("2013-02-09 12:00:00"), // Saturday
            DateTime.Parse("2013-02-10 12:00:00")  // Sunday
        };

        // Act
        var result = calculator.GetTax(vehicle, dates);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GetTax_WithPublicHoliday_ShouldReturnZero()
    {
        // Arrange
        var calculator = new CongestionTaxCalculator();
        var vehicle = new Car("Car");
        var dates = new List<DateTime>
        {
            DateTime.Parse("2013-01-01 12:00:00"), // New Year's Day
            DateTime.Parse("2013-06-12 12:00:00"), // National Day of Sweden
            DateTime.Parse("2013-11-09 12:00:00")  // Gustavus Adolphus Day
        };

        // Act
        var result = calculator.GetTax(vehicle, dates);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GetTax_WithRegularDates_ShouldReturnCorrectTotalTax()
    {
        // Arrange
        var calculator = new CongestionTaxCalculator();
        var vehicle = new Car("Car");
        var dates = new List<DateTime>
        {
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

        // Act
        var result = calculator.GetTax(vehicle, dates);

        // Assert
        Assert.Equal(97, result);
    }
}