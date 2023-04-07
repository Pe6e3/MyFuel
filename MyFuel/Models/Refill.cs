using System.ComponentModel.DataAnnotations;

namespace MyFuel.Models
{
    public class Refill
    {
        [Key]
        public int Refill_id { get; set; }
        public int Fuel_id { get; set; }
        public virtual FuelType? FuelType { get; set; }
    }
}
