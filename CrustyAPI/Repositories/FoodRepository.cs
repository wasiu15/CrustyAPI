using CrustyAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrustyAPI.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly FoodContext _context;
        public FoodRepository(FoodContext context)
        {
            _context = context;
        }
        public async Task<Food> Create(Food food)
        {
            _context.foods.Add(food);
            await _context.SaveChangesAsync();

            return food;
        }

        public async Task Delete(int Id)
        {
            var foodToDelete = await _context.foods.FindAsync(Id);
            _context.foods.Remove(foodToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Food>> Get()
        {
            return await _context.foods.ToListAsync();
        }

        public async Task<Food> Get(int Id)
        {
            return await _context.foods.FindAsync(Id);
        }

        public async Task Update(Food food)
        {
            _context.Entry(food).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
