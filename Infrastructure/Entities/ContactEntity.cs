using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class ContactEntity
{
    [Key]
    public string Id = Guid.NewGuid().ToString();

    public string FullName { get; set; } = null!;

    [Required]
    [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w{2,}$", ErrorMessage = "Email invalid")]
    public string Email { get; set; } = null!;

    public string? Services { get; set; }
      
    [Required]
    public string Message { get; set; } = null!;
}
