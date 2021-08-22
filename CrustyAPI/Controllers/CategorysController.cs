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
    [Route("api/cate")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private ICategoryRepository _categoryRepository;

        public CategorysController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryRepository.Get();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Category>> GetCategories(int Id)
        {
            return await _categoryRepository.Get(Id);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> PostFood([FromBody] Category category)
        {
            var newCategory = await _categoryRepository.Create(category);
            return CreatedAtAction(nameof(GetCategories), new { id = newCategory.Id }, newCategory);
        }

        [HttpPut]
        public async Task<ActionResult> PutCategories(int id, [FromBody] Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }
            await _categoryRepository.Update(category);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var categoryToDelete = await _categoryRepository.Get(id);
            if (categoryToDelete == null)

                return NotFound();

            await _categoryRepository.Delete(categoryToDelete.Id);
            return NoContent();

        }
    }
}
