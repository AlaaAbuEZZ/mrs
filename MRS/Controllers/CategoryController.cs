using Application.Services.CategoryService;
using Application.Services.CategoryService.CategoryDTOs;

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto input)
        {
            await _categoryService.Create(input);
            return Ok();
        }
    }
}