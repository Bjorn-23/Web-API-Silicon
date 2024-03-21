using System.ComponentModel.DataAnnotations;

namespace Web_API_Silicon.Models;

public class ReturnCourseDto
{
    [Required]
    public string Id { get; set; } = null!;

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public string Author { get; set; } = null!;

    public bool BestSeller { get; set; } = false;

    [Required]
    public string Currency { get; set; } = null!;

    [Required]
    public decimal Price { get; set; }

    public decimal? DiscountPrice { get; set; }

    [Required]
    public string LengthInHours { get; set; } = null!;

    public string? Rating { get; set; }
}