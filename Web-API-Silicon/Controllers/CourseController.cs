using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Web_API_Silicon.Filters;
using Web_API_Silicon.Models;

namespace Web_API_Silicon.Controllers;

[Route("api/[controller]")]
[ApiController]
[UseApiKey]
public class CourseController(CourseService coursesService) : ControllerBase
{
    private readonly CourseService _coursesService = coursesService;

    [HttpGet]
    public IActionResult GetAll()
    {
        //var courses = 
        return Ok();
    }

    [HttpPost]
    public IActionResult CreateCourse(CreateCourseDto model)
    {
        //if (ModelState.IsValid)
        //{
        //    var courseModel = new CourseModel()
        //    {
        //        Title = model.Title,
        //        Author = model.Author,
        //        BestSeller = model.BestSeller,
        //        Currency = model.Currency,
        //        Price = model.Price,
        //        DiscountPrice = model.DiscountPrice,
        //        LengthInHours = model.LengthInHours,
        //        Rating = model.Rating
        //    };

        //    return Created("", courseModel);
        //}

        return BadRequest(model);
    }

}
