using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web_API_Silicon.Filters;

namespace Web_API_Silicon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [UseApiKey]
    public class CategoryController(CategoryService categoryService) : ControllerBase
    {
        private readonly CategoryService _categoryService = categoryService;

        #region READ

        [HttpGet]
        public async Task<IActionResult> GetAll(string category = "")
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _categoryService.GetAllCategoriesAsync();
                    if (result != null)
                    {
                        return Ok(result);
                    }

                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("{categoryName}")]
        public async Task<IActionResult> Get(string categoryName)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _categoryService.GetOneCategoryAsync(categoryName);
                    if (result != null)
                    {
                        return Ok(result);
                    }

                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        #endregion
    }
}
