namespace Infrastructure.Models;

public class CourseResult
{
    public Pagination Pagination { get; set; } = new();

    public IEnumerable<ReturnCourseDto> ReturnCourses { get; set; } = [];
}
