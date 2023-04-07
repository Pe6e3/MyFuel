using System.ComponentModel.DataAnnotations;

namespace MyFuel.Models
{
    public class Price
    {
        [Key]
        public int Price_id { get; set; }
        public double? PriceValue { get; set; } // Нужно вытащить
        public int Fuel_id { get; set; }
    }
}
