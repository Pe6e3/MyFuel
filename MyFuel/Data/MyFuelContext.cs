using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyFuel.Models;

namespace MyFuel.Data
{
    public class MyFuelContext : DbContext
    {
        public MyFuelContext (DbContextOptions<MyFuelContext> options)
            : base(options)
        {
        }

        public DbSet<MyFuel.Models.FuelType> FuelType { get; set; } = default!;

        public DbSet<MyFuel.Models.JournalLine> JournalLine { get; set; } = default!;

        public DbSet<MyFuel.Models.Price> Price { get; set; } = default!;

        public DbSet<MyFuel.Models.Refill> Refill { get; set; } = default!;
    }
}
