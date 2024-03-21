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

    #region CREATE

    [HttpPost]
    public async Task<IActionResult> Create(CreateCourseDto model)
    {
        //if (ModelState.IsValid)
        //{
            if (model != null)
            {
                var result = await _coursesService.CreateCourseAsync(CourseFactory.Create(model));
                if (result != null)
                {
                    return Created("", CourseFactory.Create(result));
                }
                // else if result.statuscode == badrequest return badrequest
            }
        //}

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
    public async Task<IActionResult> GetAll()
    {
        if (ModelState.IsValid)
        {
            var courses = await _coursesService.GetAllCoursesAsync();
            if (courses != null)
            {
                return Ok(CourseFactory.Create(courses));
            }

            return NotFound();
        }

        return BadRequest();
    }

    #endregion

    #region UPDATE

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

    [HttpDelete]
    public async Task<IActionResult> Delete(ReturnCourseDto dto)
    {
        if (ModelState.IsValid)
        {
            if (dto != null)
            {
                var entity = CourseFactory.Create(dto);
                var courses = await _coursesService.DeleteCourseAsync(entity);
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
