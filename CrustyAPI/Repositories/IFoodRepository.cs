using CrustyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrustyAPI.Repositories
{
    public interface IFoodRepository
    {
        Task<IEnumerable<Food>> Get();
        Task<Food> Get(int Id);
        Task<Food> Create(Food food);
        Task Update(Food food);
        Task Delete(int Id);
    }
}
