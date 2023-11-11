using System.ComponentModel.DataAnnotations;

namespace TaxCalculator.Models;

public class TaxFreeDate
{
    [Key]
    public int Id { get; set; }
    public string Type { get; set; }
    public DateTime Date { get; set; }
}