using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsAPI.Models;

namespace NewsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        static List<Category> _categories = new(){
            new Category { Id = Guid.NewGuid(), Name = "General"},
            new Category { Id = Guid.NewGuid(), Name = "Course"},
            new Category { Id = Guid.NewGuid(), Name = "Laboratory"}
        };

        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(_categories);
        }

        [HttpGet("[action]")]
        public IActionResult GetCategory(Guid Id)
        {
            Category myCategory = _categories.Find(category => category.Id == Id);
            return Ok(myCategory);
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            _categories.Add(category);
            return Ok(_categories);
        }

        [HttpDelete]
        public IActionResult DeleteCategory(Guid Id)
        {
            Category myCategory = _categories.Find(category => category.Id == Id);
            _categories.Remove(myCategory);
            return Ok(_categories);
        }

    }
}
