using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrustyAPI.Models
{
    public class CategoryContext : DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Category> categories { get; set; }
    }
}
