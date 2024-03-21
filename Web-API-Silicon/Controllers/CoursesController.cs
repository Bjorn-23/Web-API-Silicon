using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Web_API_Silicon.Factories;
using Web_API_Silicon.Filters;
using Web_API_Silicon.Models;

namespace Web_API_Silicon.Controllers;

[Route("api/[controller]")]
[ApiController]
[UseApiKey]
public class CoursesController(CourseService coursesService) : ControllerBase
{
    private readonly CourseService _coursesService = coursesService;

    #region READ
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if (ModelState.IsValid)
        {
            var courses = await _coursesService.GetAllCoursesAsync();
            if (courses != null)
            {
                return Ok(CourseFactory.Create(courses));            
            }
        }

        return BadRequest();
    }
    #endregion

    [HttpPost]
    public async Task<IActionResult> Create(CreateCourseDto model)
    {
        if (ModelState.IsValid)
        {
            if (model != null)
            {
                var result = await _coursesService.CreateCourseAsync(CourseFactory.Create(model));
                if (result != null)
                {
                    return Created("", CourseFactory.Create(result));
                }
                // else if result.statuscode == badrequest return badrequest
            }    
        }

        return BadRequest(model);
    }

}
