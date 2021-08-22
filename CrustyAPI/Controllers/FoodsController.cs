using CrustyAPI.Models;
using CrustyAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrustyAPI.Controllers
{
    [Route("api/food")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodRepository _foodRepository;
        public FoodsController(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Food>> GetFoods()
        {
            return await _foodRepository.Get();
        }

        [HttpGet ("{Id}")]
        public async Task<ActionResult<Food>> GetFood(int Id)
        {
            return await _foodRepository.Get(Id);
        }

        [HttpPost]
        public async Task<ActionResult<Food>> PostFood([FromBody] Food food)
        {
            var newFood = await _foodRepository.Create(food);
            return CreatedAtAction(nameof(GetFoods), new { id = newFood.Id }, newFood);
        }

        [HttpPut]
        public async Task<ActionResult> PutFoods(int id, [FromBody] Food food)
        {
            if (id != food.Id)
            {
                return BadRequest();
            }
            await _foodRepository.Update(food);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var foodToDelete = await _foodRepository.Get(id);
            if (foodToDelete == null)

                return NotFound();

            await _foodRepository.Delete(foodToDelete.Id);            
            return NoContent();

        }
    }
}
