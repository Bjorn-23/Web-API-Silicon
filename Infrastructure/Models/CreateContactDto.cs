namespace Infrastructure.Models;

public class CreateContactDto
{
    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Services { get; set; }

    public string Message { get; set; } = null!;
}
