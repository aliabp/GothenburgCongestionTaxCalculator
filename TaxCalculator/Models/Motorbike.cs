using TaxCalculator.Interfaces;

namespace TaxCalculator.Models;

public class Motorbike : IVehicle
{
    private string _type;
    public Motorbike(string type)
    {
        _type = type;
    }
    public string GetVehicleType()
    {
        return _type;
    }
}