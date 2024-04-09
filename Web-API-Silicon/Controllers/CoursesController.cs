using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Factories;
using Web_API_Silicon.Filters;
using Infrastructure.Models;

namespace Web_API_Silicon.Controllers;

[Route("api/[controller]")]
[ApiController]
[UseApiKey]
//[Authorize]
public class CoursesController(CourseService coursesService) : ControllerBase
{
    private readonly CourseService _coursesService = coursesService;

    #region CREATE

    [Authorize] // used to authorize with JWT bearer token
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

    #endregion


    #region READ

    [HttpGet("{Id}")]
    public async Task<IActionResult> Get(string Id)
    {
        if (ModelState.IsValid)
        {
            var courses = await _coursesService.GetCourseAsync(Id);
            if (courses != null)
            {
                return Ok(CourseFactory.Create(courses));
            }

            return NotFound();
        }

        return BadRequest();
    }


    [HttpGet]
    public async Task<IActionResult> GetAll(string? category = "", string? searchQuery = "", int pageNumber  = 1, int pageSize = 9)
    {
        if (ModelState.IsValid)
        {
            var courses = await _coursesService.GetAllCoursesAsync(category, searchQuery, pageNumber, pageSize);
            if (courses != null)
            {
                return Ok(courses);
            }

            return NotFound();
        }

        return StatusCode(StatusCodes.Status500InternalServerError);
    }


    #endregion

    #region UPDATE

    [Authorize] // used to authorize with JWT bearer token
    [HttpPut]
    public async Task<IActionResult> Update(ReturnCourseDto dto)
    {
        if (ModelState.IsValid)
        {
            if (dto != null)
            {
                var entity = CourseFactory.Create(dto);
                var courses = await _coursesService.UpdateCourseAsync(entity);
                if (courses != null)
                {
                    return Ok(CourseFactory.Create(courses));
                }
            }
        }

        return BadRequest();
    }

    #endregion

    #region DELETE
    [Authorize] // used to authorize with JWT bearer token
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(string Id)
    {
        if (ModelState.IsValid)
        {
            if (!string.IsNullOrWhiteSpace(Id))
            {
                var courses = await _coursesService.DeleteCourseAsync(Id);
                if (courses != null)
                {
                    return Ok(CourseFactory.Create(courses));
                }
            }
        }

        return BadRequest();
    }

    #endregion



}
