using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrustyAPI.Models
{
    public class FoodContext : DbContext
    {
        public FoodContext(DbContextOptions<FoodContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Food> foods { get; set; }
    }
}
