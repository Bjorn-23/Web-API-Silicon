namespace Infrastructure.Entity;

public class CourseEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public bool BestSeller { get; set; } = false;
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string Currency { get; set; } = null!;
    public decimal Price { get; set; }
    public decimal? DiscountPrice { get; set; }
    public string LengthInHours { get; set; } = null!;
    public string? Rating { get; set; }

}
