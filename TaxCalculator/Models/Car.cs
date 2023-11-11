using TaxCalculator.Interfaces;

namespace TaxCalculator.Models;

public class Car : IVehicle
{
    private string _type;
    public Car(string type)
    {
        _type = type;
    }

    public string GetVehicleType()
    {
        return _type;
    }
}