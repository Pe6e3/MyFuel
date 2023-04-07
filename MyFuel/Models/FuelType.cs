using System.ComponentModel.DataAnnotations;

namespace MyFuel.Models
{
    public class FuelType
    {
        [Key]
        public int Fuel_id { get; set; }
        public string? FuelName { get; set; }
    }
}
