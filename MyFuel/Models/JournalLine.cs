using System.ComponentModel.DataAnnotations;

namespace MyFuel.Models
{
    public class JournalLine
    {
        [Key]
        public int Line_id { get; set; }

        public int Refill_id { get; set; }
        public double RefillValue { get; set; }

        public virtual Refill? Bale { get; set; }
        public virtual FuelType? FuelType { get; set; }
        public virtual Price? Price { get; set; }
    }
}
