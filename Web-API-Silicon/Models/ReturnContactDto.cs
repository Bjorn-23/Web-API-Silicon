using System.ComponentModel.DataAnnotations;

namespace Web_API_Silicon.Models;

public class ReturnContactDto
{
    public string Id { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Services { get; set; }

    public string Message { get; set; } = null!;
}
