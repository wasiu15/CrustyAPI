using CrustyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrustyAPI.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> Get();
        Task<Category> Get(int Id);
        Task<Category> Create(Category category);
        Task Update(Category category);
        Task Delete(int Id);
    }
}
