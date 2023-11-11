namespace TaxCalculator.Models;

public class Toll
{
    private DateTime _date;
    private int _amount;

    public DateTime Date { get { return _date; } set { _date = value; } }
    public int Amount { get { return _amount; } set { _amount = value; } }
}