using CrustyAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrustyAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private CategoryContext _context;
        public CategoryRepository(CategoryContext context)
        {
            _context = context;
        }

        public async Task<Category> Create(Category category)
        {
            _context.categories.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<IEnumerable<Category>> Get()
        {
            return await _context.categories.ToListAsync();
        }

        public async Task<Category> Get(int Id)
        {
            return await _context.categories.FindAsync(Id);
        }

        public async Task Update(Category categories)
        {
            _context.Entry(categories).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int Id)
        {
            var categoryToDelete = await _context.categories.FindAsync(Id);
            _context.categories.Remove(categoryToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
